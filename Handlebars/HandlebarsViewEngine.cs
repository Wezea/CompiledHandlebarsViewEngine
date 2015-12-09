using System.Web.Mvc;

namespace Handlebars
{
  public class HandlebarsViewEngine : VirtualPathProviderViewEngine
  {

    public HandlebarsViewEngine()
    {
      // Define the location of the View file
      this.ViewLocationFormats = new string[] { "~/Views/{1}/{0}.hbs", "~/Views/Shared/{0}.hbs" };
      this.PartialViewLocationFormats = new string[] { "~/Views/{1}/{0}.hbs", "~/Views/Shared/{0}.hbs" };
    }
    protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
    {
      return new HandlebarsView(CreateViewNamespace(partialPath));
    }

    protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
    {
      return new HandlebarsView(CreateViewNamespace(viewPath));
    }

    private string CreateViewNamespace(string viewPath)
    {
      return viewPath.Replace("~/", "").Replace("/", ".").Replace(".hbs", "");
    }
  }
}
