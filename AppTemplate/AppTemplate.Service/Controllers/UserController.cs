using AppTemplate.Domain.Entities;

using AppTemplate.Domain.Interfaces.Service;
using AppTemplate.Domain.Notification.Interfaces;
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
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUserTesteService _userTesteService;
        public UserController(IUserService userService, IUserTesteService userTesteService, IDomainNotification domainNotification) : base(domainNotification)
        {
            _userService = userService;
            _userTesteService = userTesteService;
        }

        // GET api/values
        public HttpResponseMessage Get()
        {
            for (int i = 0; i < 50; i++)
            {
                var user = new User("Leonardo " + i, "leo" + i + "@leo" + i + ".com.br", "PWD");
                _userService.Add(user);
            }

            var lista1 = _userService.GetAll();

            return CreateResponse(HttpStatusCode.OK, lista1);
        }

        [Route("GetByEmailAndPassword")]
        public HttpResponseMessage GetByEmailAndPassword([FromBody]string value)
        {
            if (value == null || value == "")
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Não foi passado nenhum parametro.");
            }

            var user = JsonConvert.DeserializeObject<User>(value);

            return CreateResponse(HttpStatusCode.OK, _userService.GetByEmailAndPassword(user.Email, user.Password));
        }
    }
}
