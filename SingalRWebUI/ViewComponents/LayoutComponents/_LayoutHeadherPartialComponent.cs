using Microsoft.AspNetCore.Mvc;

namespace SingalRWebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeadherPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
