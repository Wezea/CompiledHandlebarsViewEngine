using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Web.Mvc;

namespace Handlebars
{
  class HandlebarsView : IView
  {
    private string _viewPath;
    private static ConcurrentDictionary<string, Type> ViewTypes { get; set; }

    public HandlebarsView(string viewPath)
    {
      _viewPath = viewPath;
      if (ViewTypes == null)
      {
        ViewTypes = new ConcurrentDictionary<string, Type>();
      }
    }    

    public void Render(ViewContext viewContext, System.IO.TextWriter writer)
    {
      Type viewType = GetViewType(viewContext);
      MethodInfo renderMethod = viewType.GetMethod("Render");
      if (renderMethod == null)
      {
        throw new Exception($"Could not find Render Method at view {_viewPath}");
      }
      object model = viewContext.ViewData?.Model;
      string output = (string)renderMethod.Invoke(null, new object[1] { model });
      writer.Write(output);
    }   

    private Type GetViewType(ViewContext viewContext)
    {
      Type viewType = null;
      if (ViewTypes.ContainsKey(_viewPath))
      {
         viewType = ViewTypes[_viewPath];
      }
      else
      {
        Assembly assembly = viewContext.Controller.GetType().Assembly;
        string assemblyName = assembly.FullName.Substring(0, assembly.FullName.IndexOf(","));
        string viewNameSpace = CreateViewNamespace(_viewPath);
        viewType = assembly.GetType($"{assemblyName}.{viewNameSpace}");
        if (viewType == null)
        {
          throw new Exception($"Could not find view of Type '{viewNameSpace}'");
        }
        ViewTypes.AddOrUpdate(_viewPath, viewType, (path, type) => type);        
      }
      return viewType;
    }

    private static string CreateViewNamespace(string viewPath)
    {
      return viewPath.Replace("~/", "").Replace("/", ".").Replace(".hbs", "");
    }

  }
}

