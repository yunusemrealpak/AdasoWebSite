using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.Controllers
{
    public class DetailController : Controller
    {


        public IApiCall _apiCall;
        public DetailController(IApiCall apiCall, IHttpContextAccessor httpContextAccessor)
        {
            _apiCall = apiCall;

            if (httpContextAccessor.HttpContext.Request.Path.Value.ToLower() == "/adaso/mevzuat")
            {
                //PathString newUrl = new PathString("/mevzuat-2079");
                //httpContextAccessor.HttpContext.Request.Path = newUrl;

                //httpContextAccessor.HttpContext.
            }
        }

        [HttpGet]
        [Route("Haberler/{Baslik}/{id}")]
        public IActionResult Haberler(int id)
        {
            var result = "";
            PageItem item = new PageItem();
            item.Haberler = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={id}");

            //item.Haberler.Data.KucukResimUrl="0";
            //item.Haberler.Data.ResimUrl = "0";
            if (item.Haberler.Data != null)
            {
                item.YaziTipi = item.Haberler.Data.KategoriAdi;

                item.Haberler.Data.GosterimSayisi++;
                //if (item.Haberler.Data.KucukResimUrl=="" && item.Haberler.Data.ResimUrl=="")
                //{
                //    item.Haberler.Data.KucukResimUrl = "";
                //    item.Haberler.Data.ResimUrl = "";
                //}
                
         
                result = _apiCall.Post<Yazilar>("Yazilar", $"{"Update"}", item.Haberler.Data).Message;
                string albumguID = item.Haberler.Data.AlbumGUID.ToString();
                item.albumGorselleri = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumguID}");
                if (item.Haberler.Data.Grup == 1)
                {
                    item.UstIdSec = 1;
                }
            }


            return View(item);
        }

        [HttpGet]
        [Route("HaberlerTur/{Baslik}/{id}/{yazitipi}")]
        public IActionResult HaberlerTur(int id)
        {
            PageItem item = new PageItem();
            item.Haberler = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={id}");
            item.YaziTipi = item.Haberler.Data.KategoriAdi;
            string albumguID = item.Haberler.Data.GUID.ToString();
            item.albumGorselleri = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumguID}");
            if (item.Haberler.Data.Grup == 1)
            {
                item.UstIdSec = 1;
            }
            return View(item);
        }

        /// <summary>
        /// Yeni
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Baslik}-{id}")]
        public IActionResult adaso(int id)
        {
            var result = "";
            PageItem item = new PageItem();
            item.Sayfalar = _apiCall.Get<Sayfalar>("Sayfalar", $"getbyid?sayfalarId={id}");
            if (item.Sayfalar.Data != null)
            {
                item.Sayfalar.Data.GosterimSayisi++;
                result = _apiCall.Post<Sayfalar>("Sayfalar", $"{"Update"}", item.Sayfalar.Data).Message;
                item.UstIdSec = item.Sayfalar.Data.UstID;
            }

            //item.SayfalarTumliste = _apiCall.Get<List<Sayfalar>>("Sayfalar", $"getall");

            return View(item);
        }
        /// <summary>
        /// Eski url karşılama
        /// </summary>
        /// <param name="Baslik"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("adaso/{Baslik}")]
        public IActionResult adasoEskiSayfaURL(string Baslik)
        {
            //if (Baslik.ToLower() == "mevzuat")
            //{
            //    return Redirect("http://www.adaso.org.tr/mevzuat-2079");
            //}
            PageItem item = new PageItem();
            item.Sayfalar = _apiCall.Get<Sayfalar>("Sayfalar", $"getbySayfaURL?baslik={Baslik}");
            item.SayfalarTumliste = _apiCall.Get<List<Sayfalar>>("Sayfalar", $"getall");
            item.UstIdSec = item.Sayfalar.Data.UstID;
            return View(item);
        }

        /// <summary>
        /// Eski
        /// </summary>
        /// <param name="Baslik"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("adaso/{Baslik}/{id}")]
        public IActionResult googleIndex(string Baslik, int id)
        {
            PageItem item = new PageItem();
            item.stringUrl = "";
            if (Baslik == "raporlar" && id == 1)
            {

                item.stringUrl = "/dis-ticaret-raporlari-2076";

            }

            return View(item);
        }

        [HttpGet]
        [Route("AdasoDuyuru/{Baslik}/{id}")]
        public IActionResult AdasoDuyuru(int id)
        {
            var result = "";
            PageItem item = new PageItem();
            item.Haberler = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?yazilarId={id}");
            item.Haberler.Data.GosterimSayisi++;
            result = _apiCall.Post<Yazilar>("Yazilar", $"{"Update"}", item.Haberler.Data).Message;

            return View(item);
        }

        [HttpGet]
        [Route("Tebligler/{Baslik}/{id}")]
        public IActionResult Tebligler(int id)
        {
            var result = "";
            PageItem item = new PageItem();
            item.Tebligler = _apiCall.Get<Tebligler>("Tebligler", $"getbyid?tebliglerId={id}");
            item.Tebligler.Data.GosterimSayisi++;
            item.Tebligler.Data.GuncellemeTarihi = item.Tebligler.Data.GuncellemeTarihi == null ? DateTime.Now : item.Tebligler.Data.GuncellemeTarihi;
            item.Tebligler.Data.OlusturmaTarihi = item.Tebligler.Data.OlusturmaTarihi == null ? DateTime.Now : item.Tebligler.Data.OlusturmaTarihi;
            item.Tebligler.Data.Ekleyen = item.Tebligler.Data.Ekleyen == "" ? "admin" : item.Tebligler.Data.Ekleyen;
            item.Tebligler.Data.Guncelleyen = item.Tebligler.Data.Guncelleyen == "" ? "admin" : item.Tebligler.Data.Guncelleyen;
            item.Tebligler.Data.Sil = item.Tebligler.Data.Sil.ToString() == "" ? false : item.Tebligler.Data.Sil;

            result = _apiCall.Post<Tebligler>("Tebligler", $"{"Update"}", item.Tebligler.Data).Message;

            return View(item);
        }
    }
}