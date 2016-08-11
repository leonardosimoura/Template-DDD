using AppTemplate.Domain.Entities;

using AppTemplate.Domain.Interfaces.Service;
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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IUserTesteService _userTesteService;
        public UserController(IUserService userService, IUserTesteService userTesteService)
        {
            _userService = userService;
            _userTesteService = userTesteService;
        }

        // GET api/values
        public HttpResponseMessage Get()
        {
            for (int i = 0; i < 50; i++)
            {
                var user = new User("Leonardo " + i, "leo"+i+ "@leo"+i+".com.br", "PWD");
                _userService.Add(user);
            }

            var lista1 = _userService.GetAll();

            var response = Request.CreateResponse<string>(HttpStatusCode.Accepted, JsonConvert.SerializeObject(lista1));
            
            return response;
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
