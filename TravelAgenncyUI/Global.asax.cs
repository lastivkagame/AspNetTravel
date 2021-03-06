using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TravelAgenncyUI.Utils;

namespace TravelAgenncyUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutofacConfiguration.Configurate();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
