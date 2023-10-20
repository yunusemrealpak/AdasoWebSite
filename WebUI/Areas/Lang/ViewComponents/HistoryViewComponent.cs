using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents
{
    public class HistoryViewComponent : ViewComponent
    {
        [Area("En")]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
