using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;


namespace OProjeto
{
    /// <summary>
    /// Classe que representa a aplicação ASP.NET
    /// </summary>
    public class WebApiApplication : HttpApplication
    {
        /// <summary>
        /// Método que executa quando a aplicação é inicializada. Roda apenas uma vez.
        /// </summary>
        protected void Application_Start()
        {
            //Configura detalhes da rota da API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            //Configura filtros globais da aplicação
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Registra todas as dependências necessárias da aplicação
            DependencyContainerConfig.RegisterDependencies(GlobalConfiguration.Configuration);
        }
    }
}
