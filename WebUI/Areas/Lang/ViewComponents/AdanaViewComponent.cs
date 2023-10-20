using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents
{
    public class AdanaViewComponent : ViewComponent
    {
        [Area("En")]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
