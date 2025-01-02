using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
