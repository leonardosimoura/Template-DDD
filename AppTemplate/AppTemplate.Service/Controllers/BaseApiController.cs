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

        /// <summary>
        /// Cria o ResponseMessage analisando se ocorreram erros ou não
        /// </summary>
        /// <param name="statusCode">HttpStatusCode a ser retornado em caso de sucesso</param>
        /// <param name="obj">O objeto que deve ser retornado</param>
        /// <returns>HttpResponseMessage</returns>
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
