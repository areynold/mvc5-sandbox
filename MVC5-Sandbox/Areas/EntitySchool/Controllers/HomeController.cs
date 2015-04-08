using System.Web.Mvc;

namespace MVC5_Sandbox.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}