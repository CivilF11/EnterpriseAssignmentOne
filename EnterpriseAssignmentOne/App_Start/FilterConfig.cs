using System.Web;
using System.Web.Mvc;

namespace EnterpriseAssignmentOne
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
