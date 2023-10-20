using Entities.Dtos.Filter;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.Controllers
{
    public class ParitialController : Controller
    {
        public IApiCall _apiCall;

        public ParitialController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }

        [HttpPost]
        public IActionResult EtkinliklerModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["ID"].ToInt();
            item.View_Base_Hedef_Tekrar_Getir = _apiCall.Get<View_Base_Hedef_Tekrar_Getir>("View_Base_Hedef_Tekrar_Getir", $"getbyid?hedefTekrarId={id}");
            return View(item);

        }
        [HttpPost]
        public IActionResult uyeAramaDetayModal(IFormCollection collection)
        {
            //PageItem item = new PageItem();
            //string ticaretSicilNo = collection["ticaretSicilNo"];
            //item.viewUyeBilgileri = _apiCall.Get<view_Uye_Bilgileri>("viewUyeBilgileri", $"GetByIdStr?ticaretsicilNo={ticaretSicilNo}");
            //item.view_Temsilciler_list = _apiCall.Get<List<view_Temsilciler>>("view_Temsilciler", $"GetByListIdStr?uyeOID={ item.viewUyeBilgileri.Data.OID}");
            //item.view_ortaklik_list = _apiCall.Get<List<view_ortaklik>>("view_ortaklik", $"GetByListIdStr?uyeOID={ item.viewUyeBilgileri.Data.OID}");
            //item.view_UyeUyelikSabitTelefon = _apiCall.Get<List<view_UyeUyelikSabitTelefon>>("view_UyeUyelikSabitTelefon", $"GetByListIdStr?uyeOID={ item.viewUyeBilgileri.Data.OID}");

            //return View(item);
            return View();

        }

        [HttpPost]
        public IActionResult ProjeDetayModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.Projeler = _apiCall.Get<Projeler>("Projeler", $"getbyid?projelerId={id}");

            return View(item);

        }

        [HttpPost]
        public IActionResult FireKararlariDetayModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.FireKararlari = _apiCall.Get<FireKararlari>("FireKararlari", $"getbyid?FireKararlariId={id}");

            return View(item);

        }

        [HttpPost]
        public IActionResult popupGetModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            item.popup = _apiCall.Get<Yazilar>("Yazilar", $"getPopup");
            //item.FireKararlari = _apiCall.Get<FireKararlari>("FireKararlari", $"getbyid?FireKararlariId={id}");
            if (item.popup.Data != null)
            {
                return View(item);
            }
            else
            {
                return RedirectToAction("/");
            }
        }
        [HttpPost]
        public IActionResult sunumAraParitial(IFormCollection collection)
        {
            PageItem item = new PageItem();

            int sunumYear = collection["sunumYear"].ToInt();
            int sunumMounth = collection["sunumMounth"].ToInt();
            string txtContainsSearch = collection["txtContainsSearch"];

            SunumlarFilter filter = new SunumlarFilter();

            filter.sunumYear = sunumYear;
            filter.sunumMounth = sunumMounth;
            filter.anaBaslik = txtContainsSearch;
            filter.Baslik = txtContainsSearch;

            item.SunumlarSonucList = _apiCall.Post<List<Crs_Sunumlar_Sonuc>>("Crs_Sunumlar_Sonuc", $"getallwithfilter", filter);


            //durum
            //tüm sunumlar tarih seçili değilse ve ara boisa hepsi gelsin
            //item.SunumlarSonucList = _apiCall.Get<List<Crs_Sunumlar_Sonuc>>("Crs_Sunumlar_Sonuc", $"getall").Data.ToList();
            //yıl doluysa diğerleri boşsa

            return View(item);
        }
    }
}