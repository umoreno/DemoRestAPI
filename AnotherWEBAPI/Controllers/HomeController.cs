using System.Web.Mvc;

namespace AnotherWEBAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult UserAccount()
        {
            return View();
        }
    }
}
