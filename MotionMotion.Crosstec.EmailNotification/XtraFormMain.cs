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
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MotionMotion.Crosstec.EmailNotification
{
    public partial class XtraFormMain : XtraForm
    {
        private IDisposable Server;
        private bool IsServerRunning { get; set; }

        public XtraFormMain()
        {
            InitializeComponent();
            this.Text = $"{Program.ApplicationName} {Program.ApplicationVersion} - started {DateTime.Now.ToString(CultureInfo.InvariantCulture)}";
        }

        private void XtraFormMain_Shown(object sender, EventArgs e)
        {

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
    }
}