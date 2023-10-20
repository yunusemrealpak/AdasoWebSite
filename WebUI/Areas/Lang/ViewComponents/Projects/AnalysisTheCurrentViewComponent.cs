using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents.Projects
{
    public class AnalysisTheCurrentViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
