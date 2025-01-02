using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
