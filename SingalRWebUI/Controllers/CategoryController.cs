using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
