using System.Web;
using System.Web.Mvc;

namespace OProjeto
{
    /// <summary>
    /// Classe de configuração de filtros de ação da aplicação
    /// </summary>
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
