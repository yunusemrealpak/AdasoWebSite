using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents
{
    public class CapacityReportViewComponent : ViewComponent
    {
        [Area("En")]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
