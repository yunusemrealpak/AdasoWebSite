using Microsoft.AspNetCore.Mvc;

namespace AdasoEnglish.ViewComponents
{
    public class İnvestmentCertificateViewComponent : ViewComponent
    {
        [Area("En")]
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
