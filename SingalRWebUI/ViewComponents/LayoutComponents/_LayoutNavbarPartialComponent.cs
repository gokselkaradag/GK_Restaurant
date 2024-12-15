using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
