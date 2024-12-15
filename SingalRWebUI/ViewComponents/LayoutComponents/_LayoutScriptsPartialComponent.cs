using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptsPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
