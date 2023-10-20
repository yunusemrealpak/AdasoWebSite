using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents.Projects
{
    public class ConsultationServiceRegardingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
