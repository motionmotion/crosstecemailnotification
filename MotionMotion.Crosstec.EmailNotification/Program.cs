// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : Program.cs
// 
// Last Update : 2023-05-28 11:41 pm
// Create Date : 2023-05-28 11:38 pm
// 
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;

namespace MotionMotion.Crosstec.EmailNotification
{
    public static class Program
    {
        private static Mutex _appMutex;

        private const string xml_config_filename            = "ApplicationConfiguration.xml";
        private const string MutexName                      = "WEBERPEMAIL";
        public const string ApplicationName                 = "WebERP Email Notification";
        public static readonly string ApplicationVersion    = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static readonly string ServerStartTime       = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        public static ApplicationConfiguration AppConfiguration { get; set; }
        public static Thread pipe_server_thread;
        private static bool pipe_server_running;
        private static DateTime? LastRunTime;
        
        public static string sql_connection_crosstec        { get; set; }
        public static string sql_connection_weberpemail     { get; set; }

        public static void RunNotificationProcess()
        {
            WriteDebugTrace($"running notification process thread id = { Thread.CurrentThread.ManagedThreadId}");

            try
            {
                if (LastRunTime.HasValue)
                {
                    var current_datetime = DateTime.Now;

                    if (LastRunTime.Value.Year == current_datetime.Year && LastRunTime.Value.Month == current_datetime.Month && LastRunTime.Value.Day == current_datetime.Day)
                    {
                        //  ensure we only run once a day.
                        WriteDebugTrace("process already run today. request skipped.");
                    }
                }
                else
                {
                    LastRunTime = DateTime.Now;
                    WriteDebugTrace($"runtime = {LastRunTime.Value.ToString(CultureInfo.InvariantCulture)}");
                }
            }
            catch (Exception e)
            {
                WriteDebugTrace($"exception error : {e.Message}");
            }

            WriteDebugTrace($"RunNotificationProcess thread {Thread.CurrentThread.ManagedThreadId} exit");
        }

        public static void PipeServerThread()
        {
            try
            {
                NamedPipeServerStream pipeServer = new NamedPipeServerStream(AppConfiguration.server_pipename, PipeDirection.InOut);
                int threadId = Thread.CurrentThread.ManagedThreadId;
                WriteDebugTrace($"pipe server thread id : {threadId}");

                while (pipe_server_running)
                {
                    try
                    {
                        pipeServer.WaitForConnection();
                        StreamString ss = new StreamString(pipeServer);
                        string message = ss.ReadString();
                        WriteDebugTrace($"message = {message}");


                        if (message == "stop_server")
                        {
                            WriteDebugTrace("receive server stop message");
                            pipe_server_running = false;
                        }
                        else if (message == "start_task")
                        {
                            WriteDebugTrace("receive task run message");
                            Thread noticiation_process_thread = new Thread(RunNotificationProcess);
                            noticiation_process_thread.Start();
                        }
                        else if (message == "test")
                        {
                            WriteDebugTrace("receive test message. do nothing");
                        }
                    }
                    catch (Exception e)
                    {
                        WriteDebugTrace($"pipe server exception : {e.Message}");
                    }

                    pipeServer.Disconnect();

                    if (!pipe_server_running)
                    {
                        break;
                    }
                }

                if (pipeServer.IsConnected)
                {
                    WriteDebugTrace("stopping pipe server");
                    pipeServer.Close();
                }
            }
            catch (Exception e)
            {
                WriteDebugTrace($"pipe server thread exception : {e.Message}");
            }

            WriteDebugTrace($"pipe server thread {Thread.CurrentThread.ManagedThreadId} exit");
        }

        public static void StartPipeServerThread()
        {
            pipe_server_running = true;
            pipe_server_thread = new Thread(PipeServerThread);
            pipe_server_thread.Start();
        }

        public static void StopPipeServerThread()
        {
            try
            {
                var pipeClient =
                new NamedPipeClientStream(".", AppConfiguration.server_pipename,
                    PipeDirection.InOut, PipeOptions.None,
                    TokenImpersonationLevel.Impersonation);

                try
                {
                    pipeClient.Connect(1000);
                }
                catch (Exception e)
                {
                    WriteDebugTrace(e.Message);
                }

                if (pipeClient.IsConnected)
                {
                    WriteDebugTrace("send stop message to pipe");
                    var ss = new StreamString(pipeClient);
                    ss.WriteString("stop_server");
                    pipeClient.Close();
                }
                else
                {
                    WriteDebugTrace("cannot connect to pipe server.");
                }

                pipe_server_thread.Join();
            }
            catch (Exception e)
            {
                WriteDebugTrace($"exception error : {e.Message}");
            }
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style Dark");

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            
            if(!File.Exists(xml_config_filename))
            {
                WarningMessage warning = new WarningMessage();
                warning.Display("Cannot find XML configuration file", "System Message");
                return;
            }
            else
            {
                AppConfiguration = ApplicationConfiguration.Deserialize(xml_config_filename);
            }
            
            if(AppConfiguration == null)
            {
                WarningMessage warning = new WarningMessage();
                warning.Display("Cannot read XML configuration file", "System Message");
                return;
            }

            sql_connection_crosstec = AppConfiguration.sql_connection;
            sql_connection_weberpemail = AppConfiguration.sql_connection.Replace("Crosstec", "WebERPEmail");

            if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                WarningMessage warning = new WarningMessage();
                warning.Display("You must run this application as administrator. Terminating.", "System Message");
            }
            else
            {
                if (!IsSingleInstance())
                {
                    WarningMessage warning = new WarningMessage();
                    warning.Display("You must run this application as administrator. Terminating.", "System Message");
                }
                else
                {
                    Application.Run(new XtraFormMain());
                }
            }
        }

        private static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting(MutexName);
            }
            catch
            {
                _appMutex = new Mutex(true, MutexName);
                return true;
            }
            return false;

        }

        private class WarningMessage
        {
            public void Display(string messageContent, string messageCaption)
            {
                var u = new UserLookAndFeel(this)
                {
                    UseDefaultLookAndFeel = false,
                    UseWindowsXPTheme = false,
                    Style = LookAndFeelStyle.Skin,
                    SkinName = "DevExpress Dark Style"
                };

                XtraMessageBox.Show(u, messageContent, messageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void WriteDebugTraceException(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0,
            [CallerFilePath] string sourceFile = ""
        )
        {

#if TRACE
            Debug.WriteLine($"[WebERPEmailNotification][{Path.GetFileName(sourceFile)}][Exception!] <{memberName}> Line({sourceLineNumber}) {message}");
#endif
        }

        public static void WriteDebugTrace(
            string message,
            [CallerMemberName] string memberName = "",
            [CallerLineNumber] int sourceLineNumber = 0,
            [CallerFilePath] string sourceFile = ""
        )
        {

#if TRACE
            Debug.WriteLine($"[WebERPEmailNotification][{Path.GetFileName(sourceFile)}] <{memberName}> Line({sourceLineNumber}) {message}");
#endif
        }
    }
}
