// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : EmailAddressController.cs
// 
// Last Update : 2023-05-29 1:48 am
// Create Date : 2023-05-29 1:48 am
// 
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace MotionMotion.Crosstec.EmailNotification.Controller
{
    public class EmailAddressController : BaseController
    {
        [DeflateCompression]
        [HttpPost]
        [Route("api/emailaddress/add/")]
        public HttpResponseMessage add(JObject dataRequest)
        {
            try
            {

            }
            catch (Exception e)
            {
                Program.WriteDebugTraceException(e.Message);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        [DeflateCompression]
        [HttpPost]
        [Route("api/emailaddress/remove/")]
        public HttpResponseMessage remove(JObject dataRequest)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                Program.WriteDebugTraceException(e.Message);
            }

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }
    }
}
