using HandlebarsWebsite.Models;
using System.Web.Mvc;

namespace HandlebarsWebsite.Controllers
{
  public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {            
            return View(new PageModel() { Title = "Foobar!" });
        }
    }
}