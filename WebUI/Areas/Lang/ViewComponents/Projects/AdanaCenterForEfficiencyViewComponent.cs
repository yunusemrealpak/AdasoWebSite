using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents.Projects
{
    public class AdanaCenterForEfficiencyViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
