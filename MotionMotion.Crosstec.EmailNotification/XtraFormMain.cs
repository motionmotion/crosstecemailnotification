// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : XtraFormMain.cs
// 
// Last Update : 2023-05-29 12:03 am
// Create Date : 2023-05-28 11:38 pm
// 
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Owin.Hosting;

namespace MotionMotion.Crosstec.EmailNotification
{
    public partial class XtraFormMain : XtraForm
    {
        private IDisposable Server;
        private string BaseAddress { get; set; }
        private bool IsServerRunning { get; set; }

        public XtraFormMain()
        {
            InitializeComponent();
            this.Text = $"{Program.ApplicationName} {Program.ApplicationVersion} - started {DateTime.Now.ToString(CultureInfo.InvariantCulture)}";
            BaseAddress = $"http://{Program.AppConfiguration.appserver_address}:{Program.AppConfiguration.appserver_port}/";
        }

        private void XtraFormMain_Shown(object sender, EventArgs e)
        {
            if(Program.AppConfiguration.apiserver_autostart)
            {
                WriteConsoleMessage("Auto Start Enabled. Starting API Server ...", Color.Yellow);
                Program.WriteDebugTrace("auto start enabled. starting api server now ...");
                this.StartAppServer();
            }
        }

        private void XtraFormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConfirmExit())
            {
                ExitCleanup();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void StartAppServer()
        {
            if (!this.IsServerRunning)
            {
                Program.WriteDebugTrace("starting api server now.");

                try
                {
                    Server = WebApp.Start<OwinStartup>(url: BaseAddress);
                    this.IsServerRunning = true;
                    BtnStartServer.Enabled = false;
                    BtnStopServer.Enabled = true;
                    WriteConsoleMessage($"Web Server Running : {BaseAddress}", Color.LawnGreen);
                }
                catch (Exception e)
                {
                    Program.WriteDebugTraceException(e.Message);
                }
            }
            else
            {
                Program.WriteDebugTrace("server already started");
            }
        }

        private void StopAppServer()
        {
            if(this.IsServerRunning)
            {
                Program.WriteDebugTrace("stop api server now");
                Server.Dispose();
                this.IsServerRunning = false;
                BtnStartServer.Enabled = true;
                BtnStopServer.Enabled = false;
                WriteConsoleMessage($"Server Stopped", Color.Aqua);
            }
            else
            {
                Program.WriteDebugTrace("server not started");
            }
        }

        private void ExitCleanup()
        {
            
        }
        
        private static bool ConfirmExit()
        {
            var answer = XtraMessageBox.Show("Are you sure to close the application ?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.No)
            {
                return false;
            }

            return true;
        }

        private void BtnStartServer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.StartAppServer();
        }

        private void BtnStopServer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.StopAppServer();
        }

        //  -----------------------------------------------------------------
        //  console control
        //  -----------------------------------------------------------------
        
        private const int SbBottom = 0x7;
        private const int WmVscroll = 0x115;
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr window, int message, int wparam, int lparam);
        
        public void WriteConsoleMessage(string message, Color color)
        {
            consoleControl.InternalRichTextBox.Select(consoleControl.InternalRichTextBox.Text.Length, 0);
            consoleControl.WriteOutput($"{DateTime.Now:d} {DateTime.Now:HH:mm:ss} ", Color.DeepSkyBlue);
            consoleControl.WriteOutput($">> ", Color.Gray);
            consoleControl.WriteOutput(message + "\n", color);
            SendMessage(consoleControl.InternalRichTextBox.Handle, WmVscroll, SbBottom, 0x0);
        }
    }
}