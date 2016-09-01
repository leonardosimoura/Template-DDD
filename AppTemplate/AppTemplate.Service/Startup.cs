using AppTemplate.Domain.Interfaces.Service;
using AppTemplate.Service.App_Start;
using AppTemplate.Service.Security;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SimpleInjector;

namespace AppTemplate.Service
{


    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            var container = SimpleInjectorWebApiInitializer.Initialize();
            
            ConfigureWebApi(config);
            //Arumar Aqui oh
            var service = container.GetInstance<IAutenticacaoApiService>();
            ConfigureOAuth(app, service);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            WebApiConfig.Register(config);
        }
        public void ConfigureOAuth(IAppBuilder app, IAutenticacaoApiService service)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/security/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(2),
                Provider = new ApiAuthentication(service)
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}