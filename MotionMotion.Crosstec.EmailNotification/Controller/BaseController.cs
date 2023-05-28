// ---------------------------------------------------------------------------
// CrossTec WebErp Email Notification Client
// Copyright(C) 2023 Motion Motion Ltd
// Core Developer : frank@motionmotion.com
// 
// Solution : MotionMotion.Crosstec.EmailNotification
// Project : MotionMotion.Crosstec.EmailNotification
// File : BaseController.cs
// 
// Last Update : 2023-05-29 1:35 am
// Create Date : 2023-05-29 1:34 am
// 
// ---------------------------------------------------------------------------

using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MotionMotion.Crosstec.EmailNotification.Controller
{
    public class BaseController : ApiController
    {
        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST");
            return resp;
        }
    }
}
