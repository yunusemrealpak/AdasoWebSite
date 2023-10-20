using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents
{
    public class OurVisionViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
