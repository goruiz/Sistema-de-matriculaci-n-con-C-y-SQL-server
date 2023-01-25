using System.Web;
using System.Web.Mvc;

namespace matriculacion_proy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new Filtros.Verificar());
        }
    }
}
