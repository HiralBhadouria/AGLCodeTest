using AGL.BusinessLogic;
using AGL.Presentation.Controllers;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity.Mvc3;
using AGL.ExternalServices;

namespace AGLTest
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IController, PeopleController>();
            container.RegisterType<IPeopleBusinessLogic, PeopleBusinessLogic>();
            container.RegisterType<IPeopleExternalService, PeopleExternalService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            //Bootstrapper.Initialise();

        }
    }
}