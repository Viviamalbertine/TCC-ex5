using System;
using System.Web.Http;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using OProjeto.Infrastructure.Security.Hashing;
using OProjeto.Infrastructure.DataAccess;
using OProjeto.Services;

namespace OProjeto
{
    /// <summary>
    /// Classe de configuração das dependências a aplicação
    /// </summary>
    public static class DependencyContainerConfig
    {
        public static void RegisterDependencies(HttpConfiguration configuration)
        {
            // Cria o container de dependências da aplicação
            var container = new Container();

            // Registra os tipos das dependências
            container.Register(typeof(HashProvider));
            container.Register(typeof(StudentServices));
            container.Register(typeof(StudentRepository));
            container.RegisterWebApiControllers(configuration);

            // Configura o SimpleInjector como o responsável pelo resolução de dependências da aplicação
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}