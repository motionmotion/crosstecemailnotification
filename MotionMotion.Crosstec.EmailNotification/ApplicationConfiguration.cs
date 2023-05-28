// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : ApplicationConfiguration.cs
// 
// Last Update : 2023-05-29 12:10 am
// Create Date : 2023-05-29 12:10 am
// 
// ---------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.IO;

namespace MotionMotion.Crosstec.EmailNotification
{
    public class ApplicationConfiguration
    {
        public int      email_server_type               { get; set; }
        public int      enable_test_mode                { get; set; }
        public string   weberp_server_ip                { get; set; }
        public string   sql_connection                  { get; set; }
        public string   email_office365_sender          { get; set; }
        public string   email_office365tenant_id        { get; set; }
        public string   email_office365application_id   { get; set; }
        public string   email_office365client_secret    { get; set; }
        public string   email_smpt_host                 { get; set; }
        public string   email_smpt_sender_email         { get; set; }
        public string   email_smpt_sender_password      { get; set; }
        public string   server_pipename                 { get; set; }
        public string   appserver_appname               { get; set; }
        public string   appserver_address               { get; set; }
        public int      appserver_port                  { get; set; }
        public bool     apiserver_autostart             { get; set; }
        
        public static void CreateTemplateXMLConfig(string filename)
        {
            ApplicationConfiguration tmp = new ApplicationConfiguration();
            tmp.email_server_type               = 1;
            tmp.enable_test_mode                = 0;
            tmp.sql_connection                  = "null";
            tmp.email_office365_sender          = "null";
            tmp.email_office365tenant_id        = "null";
            tmp.email_office365application_id   = "null";
            tmp.email_office365client_secret    = "null";
            tmp.email_smpt_host                 = "null";
            tmp.email_smpt_sender_email         = "null";
            tmp.email_smpt_sender_password      = "null";
            tmp.weberp_server_ip                = "192.168.0.250";
            tmp.server_pipename                 = "weberppipe";
            Serialize(filename, tmp);
        }

        private static int Serialize(string file, ApplicationConfiguration c)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xs
                    = new System.Xml.Serialization.XmlSerializer(c.GetType());
                StreamWriter writer = File.CreateText(file);
                xs.Serialize(writer, c);
                writer.Flush();
                writer.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return -1;
        }

        public static ApplicationConfiguration Deserialize(string file)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer xs
                    = new System.Xml.Serialization.XmlSerializer(
                        typeof(ApplicationConfiguration));
                StreamReader reader = File.OpenText(file);
                ApplicationConfiguration c = (ApplicationConfiguration)xs.Deserialize(reader);
                reader.Close();
                return c;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            return null;
        }

    }
}
