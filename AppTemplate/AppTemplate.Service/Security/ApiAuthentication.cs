using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using AppTemplate.Domain.Entities;
using AppTemplate.Domain.Interfaces.Service;

namespace AppTemplate.Service.Security
{
    public class ApiAuthentication : OAuthAuthorizationServerProvider
    {
        private readonly IAutenticacaoApiService _service;

        public ApiAuthentication(IAutenticacaoApiService service)
        {
            _service = service;
        }


        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Para aceitar Requisições de todos os ips
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            try
            {
                //var user = new User() { Email = context.UserName, Name = context.UserName, Password = context.Password };
                var user = _service.Authenticate(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "Usuário ou senha invalidos");
                    return;
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Name));

                //Adiciona um a um os roles
                //identity.AddClaim(new Claim(ClaimTypes.Role, "Role"));

                //Passa um list<String>  que são os roles
                //GenericPrincipal principal = new GenericPrincipal(identity, listaRoles);
                GenericPrincipal principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;

                context.Validated(identity);
            }
            catch (Exception ex)
            {
                context.SetError("invalid_grant", "Usuário ou senha invalidos");
            }
        }
    }
}