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
    [RoutePrefix("api/user")]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWorkTS _unitOfWork;

        public UserController(IUserService userService, IUnitOfWorkTS unitOfWork) : base(unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        public HttpResponseMessage Get()
        {

            var listaAdd1 = new List<User>();
            // Teste 
            for (int i = 0; i < 10; i++)
            {
                
                var user = new User("Leonardo", "leonardo@evoluaeducacao.com.br","password");
                //var user = new User("Leonardo", "leonardo.com.br", "password");
                listaAdd1.Add(user);
            }

            _userService.AddRange(listaAdd1);

            var lista = _userService.GetAll();

            _unitOfWork.Commit();

            return CreateResponse(HttpStatusCode.OK, lista);
        }

        [HttpPost]
        [Route("GetByEmailAndPassword")]
        public HttpResponseMessage GetByEmailAndPassword(User user)
        {
            return CreateResponse(HttpStatusCode.OK, _userService.GetByEmailAndPassword(user.Email, user.Password));
        }
    }
}
