using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace HandlebarsWebsite.Views.Page
{
  [CompiledHandlebarsTemplate]
  public static class Index
  {
    public static string Render(HandlebarsWebsite.Models.PageModel viewModel)
    {
      var sb = new StringBuilder(64);
      sb.Append("\r\n");
      ; /*layout ~/Views/Layout/Main.hbs*/
      sb.Append("\r\n<h1>");
      sb.Append(WebUtility.HtmlEncode(viewModel.Title));
      sb.Append("</h1>");
      return sb.ToString();
    }

    private static bool IsTruthy(bool b)
    {
      return b;
    }

    private static bool IsTruthy(string s)
    {
      return !string.IsNullOrEmpty(s);
    }

    private static bool IsTruthy(object o)
    {
      return o != null;
    }

    private static bool IsTruthy<T>(IEnumerable<T> ie)
    {
      return ie != null && ie.Any();
    }

    private static bool IsTruthy(int i)
    {
      return i != 0;
    }

    private class CompiledHandlebarsTemplateAttribute : Attribute
    {
    }

    private class CompiledHandlebarsLayoutAttribute : Attribute
    {
    }
  }
}/*compiled in 25ms*/