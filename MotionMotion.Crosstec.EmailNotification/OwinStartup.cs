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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Microsoft.Owin.StaticFiles.ContentTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;

namespace MotionMotion.Crosstec.EmailNotification
{
    public class OwinStartup
    {
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

            //config.MessageHandlers.Add(new CustomDelegatingHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = System.Web.Http.RouteParameter.Optional }
            );

            //  Microsoft.Owin.StaticFiles will handle all static file request from client.
            //  assets/images/
            //  assets/javascript
            //  assets/webix

            //StaticFileOptions options = new StaticFileOptions();
            //options.FileSystem = new PhysicalFileSystem(AssetPath);
            //options.RequestPath = new PathString($"/assets");
            //options.ServeUnknownFileTypes = true;
            //options.ContentTypeProvider = new CustomFileExtensionContentTypeProvider();

            appBuilder.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            //appBuilder.UseStaticFiles(options);
            appBuilder.UseWebApi(config);
        }
    }
}
