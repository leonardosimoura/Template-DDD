using AppTemplate.Domain.Notification.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AppTemplate.Service.Controllers
{
    public class BaseApiController : ApiController
    {
        private readonly IDomainNotification _domainNotication;
        public BaseApiController(IDomainNotification domainNotication)
        {
            _domainNotication = domainNotication;
        }

        public HttpResponseMessage CreateResponse(HttpStatusCode statusCode = HttpStatusCode.OK,object obj = null)
        {
            HttpResponseMessage response;

            if (_domainNotication.HasError())
            {
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = _domainNotication.GetAllErrors() });
            }
            else
            {
                response = Request.CreateResponse(statusCode, new { notifications = _domainNotication.GetAllNotifications(), obj = obj});
            }

            return response;
        }
        

    }
}
