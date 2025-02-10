using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
