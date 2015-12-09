using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Collections.Generic;

namespace HandlebarsWebsite
{
  [CompiledHandlebarsLayout]
  public static class Layout
  {
    public static string PostRender(HandlebarsWebsite.Models.PageModel viewModel)
    {
      var sb = new StringBuilder(64);
      sb.Append("\r\n</body>\r\n</html>");
      return sb.ToString();
    }

    public static string PreRender(HandlebarsWebsite.Models.PageModel viewModel)
    {
      var sb = new StringBuilder(64);
      sb.Append("\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <meta charset=\"utf-8\" />\r\n  <meta name=\"viewport\" content=\"width=device-width\" />\r\n  <title>");
      sb.Append(WebUtility.HtmlEncode(viewModel.Title));
      sb.Append("</title>\r\n</head>\r\n<body>\r\n  ");
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
}/*compiled in 5ms*/