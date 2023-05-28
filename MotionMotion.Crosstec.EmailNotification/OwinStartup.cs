// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : OwinStartup.cs
// 
// Last Update : 2023-05-29 1:33 am
// Create Date : 2023-05-28 11:59 pm
// 
// ---------------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace MotionMotion.Crosstec.EmailNotification
{
    public class OwinStartup
    {

        private readonly string AssetPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "content";

        private static string WebAppContent()
        {
            string webapp_basename = Program.AppConfiguration.appserver_appname;
            string webapp_caption = "Crosstec WebERP Email Notification";
            
            StringBuilder sb = new StringBuilder();

            sb.Append($"<!DOCTYPE html><html><head><meta charset=\"utf-8\"><title>{webapp_caption}</title>");
            sb.Append("<html><body>");

            //  SweetAlert2 
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets/webix/sweetalert2.min.css\">");
            sb.Append("<script type=\"text/javascript\" src=\"assets/webix/sweetalert2.all.min.js\"></script>");

            //  Web App External References
            sb.Append($"<script type=\"text/javascript\" src=\"assets/webix/webix.js?{Guid.NewGuid().ToString()}\"></script>");
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets/webix/webix.min.css\">");
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets/webix/mini.css\">");
            sb.Append("<link rel=\"stylesheet\" type=\"text/css\" href=\"assets/webix/materialdesignicons.min.css\">");

            //  Web App Runtime Javascript 
            sb.Append($"<script type=\"text/javascript\" src=\"assets/codebase/{webapp_basename}.js?{Guid.NewGuid().ToString()}\"></script>");
            sb.Append($"<link rel=\"stylesheet\" type=\"text/css\" href=\"assets/codebase/{webapp_basename}.css?{Guid.NewGuid().ToString()}\">");
            sb.Append("</head><body></body></html>");

            return sb.ToString();
        }

        public class CustomDelegatingHandler : DelegatingHandler
        {
            //  This handler will send the index content when there are no matched route found. 
            //  eg http://192.168.1.13/9000 -> will render the content from index.html

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                Task<HttpResponseMessage> response = base.SendAsync(request, cancellationToken);
                string tmp = request.RequestUri.LocalPath.ToString();

                #region Render WebApp HTML Content

                if (tmp == "/")
                {
                    if (response.Result.StatusCode == HttpStatusCode.NotFound)
                    {
                        string content = WebAppContent();

                        try
                        {
                            if (File.Exists("content.html"))
                            {
                                string tmp2 = File.ReadAllText("content.html");

                                if (!string.IsNullOrEmpty(tmp2))
                                {
                                    content = tmp2;
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Program.WriteDebugTraceException(e.Message);
                        }

                        response.Result.Content = new StringContent(content);
                        response.Result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                        response.Result.StatusCode = HttpStatusCode.OK;
                    }
                }

                #endregion

                #region System Information HTML Page

                if (tmp == "/info.html")
                {
                    if (response.Result.StatusCode == HttpStatusCode.NotFound)
                    {
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<!DOCTYPE html>");
                            sb.Append("<html><body>");
                            sb.Append("<p>Crosstec WebERP Email Notification</p>");
                            sb.Append($"<p>Version : {Program.ApplicationVersion}</p>");
                            sb.Append($"<p>Server Started : {Program.ServerStartTime}</p>");
                            sb.Append($"<p>Motion Motion Limited 2023</p>");
                            sb.Append("</body></html>");
                            string contentStr = sb.ToString();
                            response.Result.Content = new StringContent(contentStr);
                            response.Result.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                            response.Result.StatusCode = HttpStatusCode.OK;
                        }
                        catch (Exception e)
                        {
                            Program.WriteDebugTraceException(e.Message);
                        }
                    }
                }

                #endregion

                return response;
            }
        }

        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            config.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

            config.MessageHandlers.Add(new CustomDelegatingHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

            //  Microsoft.Owin.StaticFiles will handle all static file request from client.
            //  assets/images/
            //  assets/javascript
            //  assets/webix

            StaticFileOptions options = new StaticFileOptions();
            options.FileSystem = new PhysicalFileSystem(AssetPath);
            options.RequestPath = new PathString("/assets");
            options.ServeUnknownFileTypes = true;

            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            appBuilder.UseStaticFiles(options);
            appBuilder.UseWebApi(config);
        }
    }
}
