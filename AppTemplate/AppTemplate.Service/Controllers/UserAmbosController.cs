using AppTemplate.Domain.Entities;

using AppTemplate.Domain.Interfaces.Service;
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
    public class UserAmbosController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserTesteService _userTesteService;
        private readonly IUnitOfWork _unitOfWork;
        public UserAmbosController(IUserService userService, IUserTesteService userTesteService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _userTesteService = userTesteService;
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        public HttpResponseMessage Get()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    var user = new User("Leonardo " + i, "leo" + i + "@leo" + i + ".com.br", "PWD");
                    _userService.Add(user);
                }

                var lista1 = _userService.GetAll();

                for (int i = 0; i < 50; i++)
                {
                    var user = new User("Leonardo " + i, "leo" + i + "@leo" + i + ".com.br", "PWD");
                    _userTesteService.Add(user);
                }

                var lista2 = _userTesteService.GetAll();

                var response = Request.CreateResponse<string>(HttpStatusCode.Accepted, "Terminou");
                Thread.Sleep(20000);
                return response;
            }
            catch (Exception ex)
            {
                var Notifications = _unitOfWork.GetAllNotifications();

                var Errors = _unitOfWork.GetAllErrors();

                throw ex;

            }
            
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
