using System;
using System.Web.Http;

namespace OProjeto
{
    /// <summary>
    /// Classe de configuração das rotas de acesso à aplicação
    /// </summary>
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuta a aplicação para atender a requisições de outros domínios além do local
            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
