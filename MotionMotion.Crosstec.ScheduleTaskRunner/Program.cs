// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.ScheduleTaskRunner
// File : Program.cs
// 
// Last Update : 2023-05-28 11:45 pm
// Create Date : 2023-05-28 11:45 pm
// 
// ---------------------------------------------------------------------------

using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Text;

namespace MotionMotion.Crosstec.ScheduleTaskRunner
{

    public class StreamString
    {
        private Stream ioStream;
        private UnicodeEncoding streamEncoding;

        public StreamString(Stream ioStream)
        {
            this.ioStream = ioStream;
            streamEncoding = new UnicodeEncoding();
        }

        public string ReadString()
        {
            int len;
            len = ioStream.ReadByte() * 256;
            len += ioStream.ReadByte();
            var inBuffer = new byte[len];
            ioStream.Read(inBuffer, 0, len);

            return streamEncoding.GetString(inBuffer);
        }

        public int WriteString(string outString)
        {
            byte[] outBuffer = streamEncoding.GetBytes(outString);
            int len = outBuffer.Length;
            if (len > UInt16.MaxValue)
            {
                len = (int)UInt16.MaxValue;
            }
            ioStream.WriteByte((byte)(len / 256));
            ioStream.WriteByte((byte)(len & 255));
            ioStream.Write(outBuffer, 0, len);
            ioStream.Flush();

            return outBuffer.Length + 2;
        }

    }

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    string pipename = args[0];

                    var pipeClient =
                        new NamedPipeClientStream(".", pipename,
                            PipeDirection.InOut, PipeOptions.None,
                            TokenImpersonationLevel.Impersonation);

                    try
                    {
                        pipeClient.Connect(1000);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    if (pipeClient.IsConnected)
                    {
                        Console.WriteLine("connected to pipe server");
                        Console.WriteLine("send start task message to notification process");
                        var ss = new StreamString(pipeClient);
                        ss.WriteString("start_task");
                        pipeClient.Close();
                    }
                    else
                    {
                        Console.WriteLine("cannot connect to pipe server. notification process is not running");
                    }
                }
                else
                {
                    Console.WriteLine("no pipe name set in command line argument");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"exception error {e.Message}");
            }
        }
    }
}
