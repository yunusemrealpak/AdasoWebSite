using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Lang.Controllers
{
    [Area("Lang")]
    public class EnController : Controller
    {
        public IActionResult Index()
        {
            TempData["link"] = Request.Query["link"].ToString();
            return View();
        }
    }
}