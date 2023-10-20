using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Lang.ViewComponents
{
    public class AidatViewComponent : ViewComponent
    {
        [Area("En")]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
