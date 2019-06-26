using System.Web;
using System.Web.Mvc;

namespace Ad_Link_Pro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
