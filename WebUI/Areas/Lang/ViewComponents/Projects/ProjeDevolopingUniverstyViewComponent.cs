using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents.Projects
{
    public class ProjeDevolopingUniverstyViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
