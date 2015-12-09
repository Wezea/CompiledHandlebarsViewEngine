using HandlebarsWebsite.App_Start;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace HandlebarsWebsite
{
  public class Global : System.Web.HttpApplication
  {

    protected void Application_Start(object sender, EventArgs e)
    {
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      ViewEngines.Engines.Add(new Handlebars.HandlebarsViewEngine());
    }  
  
  }
}