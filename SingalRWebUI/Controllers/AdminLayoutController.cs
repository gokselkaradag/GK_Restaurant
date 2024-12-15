using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
