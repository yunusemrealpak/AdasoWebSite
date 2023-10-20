using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents.Projects
{
    public class MahirEller1ViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
