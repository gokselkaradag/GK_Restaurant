using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutSidebarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
