using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class SignalRDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
