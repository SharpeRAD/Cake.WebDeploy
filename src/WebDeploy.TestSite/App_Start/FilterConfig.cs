using System.Web;
using System.Web.Mvc;

namespace Cake.WebDeploy.TestSite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
