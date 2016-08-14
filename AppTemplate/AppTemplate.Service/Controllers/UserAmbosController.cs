using AppTemplate.Domain.Entities;

using AppTemplate.Domain.Interfaces.Service;
using AppTemplate.Domain.Notification.Interfaces;
using AppTemplate.Domain.Transaction.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace AppTemplate.Service.Controllers
{
    [RoutePrefix("api/userambos")]
    public class UserAmbosController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUserTesteService _userTesteService;
        public UserAmbosController(IUserService userService, IUserTesteService userTesteService, IDomainNotification domainNotification) : base(domainNotification)
        {
            _userService = userService;
            _userTesteService = userTesteService;
        }

        // GET api/values
        public HttpResponseMessage Get()
        {
            for (int i = 0; i < 50; i++)
            {
                //var user = new User("Leonardo " + i, "leo" + i + "@leo" + i + ".com.br", "PWD");
                var user = new User("","", "");
                _userService.Add(user);
            }

            var lista1 = _userService.GetAll();


            //for (int i = 0; i < 50; i++)
            //{
            //    var user = new User("Leonardo " + i, "leo" + i + "@leo" + i + ".com.br", "PWD");
            //    _userTesteService.Add(user);
            //}



            //var lista2 = _userTesteService.GetAll();
            //Thread.Sleep(20000);
            return CreateResponse(HttpStatusCode.OK, lista1);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var response = Request.CreateResponse<string>(HttpStatusCode.Accepted, JsonConvert.SerializeObject(_userService.GetById(id)));

            return response;
        }

        [Route("GetByEmailAndPassword")]
        public HttpResponseMessage GetByEmailAndPassword([FromBody]string value)
        {
            try
            {
                if (value == null || value == "")
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi passado nenhum parametro.");
                }

                var user = JsonConvert.DeserializeObject<User>(value);

                return Request.CreateResponse<string>(HttpStatusCode.Accepted, JsonConvert.SerializeObject(_userService.GetByEmailAndPassword(user.Email, user.Password)));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            var response = Request.CreateResponse(HttpStatusCode.Accepted);

            return response;
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            var response = Request.CreateResponse(HttpStatusCode.Accepted);

            return response;
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Accepted);

            return response;
        }
    }
}
