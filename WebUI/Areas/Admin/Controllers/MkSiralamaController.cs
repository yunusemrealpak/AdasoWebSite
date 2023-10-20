using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MkSiralamaController : Controller
    {
        public IApiCall _apiCall;
        public MkSiralamaController(IApiCall apiCall)
        { 
            _apiCall = apiCall;
        }
        
        public IActionResult MkSiralama()
        {
            TempData["MkSiralama"] = "active";
            TempData["HizliIkon"] = "active";

            var sess = HttpContext.Session.GetString("SessionList");
           List<MKUyeler> mkuyeler = new List<MKUyeler>();

            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            else
            {
                mkuyeler = _apiCall.Get<List<MKUyeler>>("MKUyeler", "Getall").Data;
                mkuyeler.Where(x => x.DonemID == 3);
            }
            return View(mkuyeler);
        }

 
    }
}
