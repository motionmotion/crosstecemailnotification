// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : SystemController.cs
// 
// Last Update : 2023-05-29 1:23 am
// Create Date : 2023-05-29 1:23 am
// 
// ---------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MotionMotion.Crosstec.EmailNotification.Controller
{
    public class SystemController : BaseController
    {
        [DeflateCompression]
        [HttpGet]
        [Route("api/System/ServerVersion/")]
        public HttpResponseMessage ServerVersion()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent($"Server version: {Program.ApplicationVersion}");
            return response;
        }

        [DeflateCompression]
        [HttpGet]
        [Route("api/System/Ping/")]
        public HttpResponseMessage Ping()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent($"Pong {DateTime.Now.ToString(CultureInfo.InvariantCulture)}");
            return response;
        }
        
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST");
            return resp;
        }
    }
}
