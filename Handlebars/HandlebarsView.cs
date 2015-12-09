using System.Reflection;
using System.Web.Mvc;

namespace Handlebars
{
  class HandlebarsView : IView
  {
    private string _viewNampespace;

    public HandlebarsView(string @nampespace)
    {
      _viewNampespace = @nampespace;
    }    

    public void Render(ViewContext viewContext, System.IO.TextWriter writer)
    {
      Assembly assembly = viewContext.Controller.GetType().Assembly;
      string assemblyName = assembly.FullName.Substring(0, assembly.FullName.IndexOf(","));
      MethodInfo renderMethod = assembly.GetType($"{assemblyName}.{_viewNampespace}").GetMethod("Render");
      string output = (string)renderMethod.Invoke(null, new object[1] { viewContext.ViewData.Model });
      writer.Write(output);
    }   
  
  }
}

