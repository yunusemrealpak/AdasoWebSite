using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class ParitialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult GetHaberFormModal(IFormCollection collection)
        {


            return View();
        }

    }
}
