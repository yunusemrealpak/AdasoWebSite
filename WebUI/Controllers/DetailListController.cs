using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.Controllers
{
    public class DetailListController : Controller
    {
        public IApiCall _apiCall;

        public DetailListController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }

        [HttpGet]
        [Route("AdasoDetay/{sayfa}")]
        public IActionResult AdasoDetay(string sayfa)
        {
            PageItem item = new PageItem();
            item.YaziTipi = sayfa;
            ViewData["sayfaListe"] = sayfa;

            return View(item);
        }

        [HttpGet]
        [Route("AdasoHaberDetay/{sayfa}/{Grup}")]
        public IActionResult AdasoHaberDetay(string sayfa, string kategoriAdi)
        {
            PageItem item = new PageItem();
            item.YaziTipi = kategoriAdi;
            ViewData["sayfaListe"] = sayfa;
            return View(item);
        }
    }
}
