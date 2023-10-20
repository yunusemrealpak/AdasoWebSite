using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DropDownController : Controller
    {
        public IApiCall _apiCall;
        public DropDownController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }

        public IActionResult GetirFiltre(int id = 0, int grupKod = 0, string AnaGrupKod = "", string Sorgu = "", int Adet = 0, string type = "", int sayfa = 0, string arama = "")
        {
            if (AnaGrupKod == "YaziTip")
            {
                var result = _apiCall.Get<List<Yazilar>>("Yazilar", "getall");
                if (result.Success)
                {
                    return Json(new { results = result.Data.Where(x => x.Baslik.Contains(arama)).Skip(sayfa * 10).Take(10).Select(x => new { id = x.ID, kod = x.ID, text = x.Baslik }), pagination = new { more = true } });
                }
            }
            else if (AnaGrupKod == "Kullanici")
            {
                var result = _apiCall.Get<List<Yazilar>>("Yazilar", "getall");
                if (result.Success)
                {
                    return Json(new { results = result.Data.Where(x => x.Baslik.Contains(arama)).Skip(sayfa * 10).Take(10).Select(x => new { id = x.ID, kod = x.ID, text = x.Baslik }), pagination = new { more = true } });
                }

            }
            return Json("");
        }
    }
}
