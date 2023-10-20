using Core.Aspects.Autofac.Caching;
using Entities.Dtos.Filter;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;
using static Core.Utilities.Security.Encyption.SecurityKeyHelper;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IApiCall _apiCall;

        public HomeController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
    
        public IActionResult Index(IFormCollection collection)
        {

            PageItem item = new PageItem();

            #region Get Çağrı
            FilterFullCalendar filter = new FilterFullCalendar();
            string from = collection["from"];
            string to = collection["to"];

            if (from == null && to == null)
            {
                filter.start = DateTime.Now.AddYears(-1);
                filter.end = DateTime.Now;
            }
            else
            {
                filter.start = Convert.ToDateTime(collection["from"]);
                filter.end = Convert.ToDateTime(collection["to"]);
            }

            RaporFilter Rapor1Filter = new RaporFilter();
            RaporFilter Rapor2Filter = new RaporFilter();
            Rapor1Filter.Take = 4;
            Rapor1Filter.Tip = 1;
            Rapor1Filter.Etkin = true;

            Rapor2Filter.Take = 4;
            Rapor2Filter.Tip = 2;
            Rapor2Filter.Etkin = true;

            item.sliders = _apiCall.Get<List<Yazilar>>("Yazilar", "Slider");

            item.RaporlarTip1 = _apiCall.Post<List<Raporlar>>("Raporlar", $"GetRaporTip", Rapor1Filter);
            item.RaporlarTip2 = _apiCall.Post<List<Raporlar>>("Raporlar", $"GetRaporTip", Rapor2Filter);

            //item.View_Base_Hedef_Tekrar_Getir_List = _apiCall.Get<List<View_Base_Hedef_Tekrar_Getir>>("View_Base_Hedef_Tekrar_Getir", $"getall");
            item.View_Base_Hedef_Tekrar_Getir_List = new ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>>();
            //item.EtkinlikTakvimi = item.EtkinlikTakvimi = _apiCall.Post<List<Etkinlikler>>("Etkinlikler", $"GetListHomePageActives", filter);

            if (item.sliders.Success)
                return View(item);

            else if (item.RaporlarTip1.Success)
                return View(item);

            else if (item.RaporlarTip2.Success)
                return View(item);
            else if (item.EtkinlikTakvimi.Success)
                return View(item.EtkinlikTakvimi.Data.Take(10));

            #endregion Get Çağrı

            //#region Post
            //Kullanicilar k = new Kullanicilar();
            //k.Ad = "sdfsdfsdfdsf";
            //k.Soyad = "dsfsdfsdfsdf";
            //var result = _apiCall.Post<Kullanicilar>("Kullanicilar", "add", k);
            //#endregion

            return View(item);
        }
        public IActionResult _Index()
        {
            //data-mode = "popupGetModal"
            var result = _apiCall.Get<List<Kullanicilar>>("Kullanicilar", "getall");
            if (result.Success)
            {
                return Json(result);
            }

            return Json(result);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region takvim işlemler  
        public JsonResult GetEtkinlikTakvim(FilterFullCalendar filter)
        {
            PageItem item = new PageItem();
            item.View_Base_Hedef_Tekrar_Getir_List = _apiCall.Get<List<View_Base_Hedef_Tekrar_Getir>>("View_Base_Hedef_Tekrar_Getir", $"getall");

            try
            {

                var json = Json(item.View_Base_Hedef_Tekrar_Getir_List.Data.Select(x1 => new
                {
                    title = x1.hedefTekrarFaaliyetBasTarih.ToString("HH:mm") + "  \n  " + x1.hedefTekrarFaaliyetBitTarih.ToString("HH:mm") + "  \n  " + x1.hedefTekrarBaslik,

                    start = Convert.ToDateTime(x1.hedefTekrarFaaliyetBasTarih).ToString("yyyy-MM-dd HH:mm:ss"),

                    end = Convert.ToDateTime(x1.hedefTekrarFaaliyetBitTarih).ToString("yyyy-MM-dd HH:mm:ss"),

                    bastar = Convert.ToDateTime(x1.hedefTekrarFaaliyetBasTarih).ToString("yyyy-MM-dd HH:mm:ss"),

                    bittar = Convert.ToDateTime(x1.hedefTekrarFaaliyetBitTarih).ToString("yyyy-MM-dd HH:mm:ss"),

                    id = x1.ID

                }));
                return json;
            }
            catch (Exception ex)
            {

                return Json(ex.Message);
            }


        }

        #endregion

        public string iletisimFormIslem(IFormCollection collection)
        {

            PageItem item = new PageItem();
            MesajKuyruklar mesajkuyruk = new MesajKuyruklar();
            mesajkuyruk.UygulamaAdi = "AdasoWeb";
            mesajkuyruk.mesajKuyrukTip = "Mail";
            mesajkuyruk.mesajKuyrukAltTip = "iletisimForm";
            mesajkuyruk.PersonelAdi = collection["txtadSoyad"];
            mesajkuyruk.PersonelSoyadi = collection["txtadSoyad"];
            mesajkuyruk.PersonelEmail = "sanayi@adaso.org.tr,yazi@adaso.org.tr,ozelkalem@adaso.org.tr";
            mesajkuyruk.baslik = "İletişim / Şikayet - Öneri Formu";
            mesajkuyruk.mesajKuyrukBaslik = collection["txtKonu"];
            mesajkuyruk.mesajKuyrukIcerik = collection["textareaAciklama_"] + "<br>" + collection["txtTelefon"] + "<br>" + collection["txtEposta"] + "<br>" + collection["textareaAdres"];
            mesajkuyruk.mesajKuyrukDosyaOlTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukDosyaGonTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukGonderildiMi = false;

            var response = Request.Form["g-recaptcha-response"];
            const string secret = "6Lf3QFcdAAAAAK3pgApPgxyRJDMFiEgEiAB_Z7ff";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (!captchaResponse.Success)
            {

                return "Hata|Lütfen Güvenliğinizi Doğrulayınız.";
            }
            else
            {
                var result = _apiCall.Post<List<MesajKuyruklar>>("MesajKuyruklar", $"Add", mesajkuyruk);

                return MessageHelper.SuccessMessage;
            }

        }
        public string bilgiEdinmeFormIslem(IFormCollection collection)
        {

            PageItem item = new PageItem();
            MesajKuyruklar mesajkuyruk = new MesajKuyruklar();
            mesajkuyruk.UygulamaAdi = "AdasoWeb";
            mesajkuyruk.mesajKuyrukTip = "Mail";
            mesajkuyruk.mesajKuyrukAltTip = "BilgiEdinmeForm";
            mesajkuyruk.PersonelAdi = collection["txtadSoyad"];
            mesajkuyruk.PersonelSoyadi = collection["txtadSoyad"];
            mesajkuyruk.PersonelEmail = "basin@adaso.org.tr,yazi@adaso.org.tr,sanayi@adaso.org.tr";
            mesajkuyruk.baslik = "Bilgi Edinme Formu";
            mesajkuyruk.mesajKuyrukBaslik = collection["txtKonu"];
            string cevapTipi = collection["radioEposta"] == "on" ? "Eposta ile cevap almak istiyorum." : collection["radioYazili"] == "on" ? "Yazılı olarak cevap almak istiyorum." : "Cevap Yolu Seçilmedi";
            mesajkuyruk.mesajKuyrukIcerik =
                    "<h3>" + collection["selectBasvuruTipi"] + "</h3><br>" +
                    "Açıklama &nbsp;&nbsp;&nbsp;:&nbsp;" + collection["textareaAciklama_"] + "<br>" +
                    "Tc Kimlik &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["txtTCKN"] + "<br>" +
                    "E posta &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["txtEposta"] + "<br>" +
                    "Cevap Yolu &nbsp;&nbsp;&nbsp;: &nbsp; " + cevapTipi + "<br>";

            mesajkuyruk.mesajKuyrukDosyaOlTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukDosyaGonTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukGonderildiMi = false;

            var response = Request.Form["g-recaptcha-response"];
            const string secret = "6Lf3QFcdAAAAAK3pgApPgxyRJDMFiEgEiAB_Z7ff";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (!captchaResponse.Success)
            {

                return "Hata|Lütfen Güvenliğinizi Doğrulayınız.";
            }
            else
            {
                var result = _apiCall.Post<List<MesajKuyruklar>>("MesajKuyruklar", $"Add", mesajkuyruk);

                return MessageHelper.SuccessMessage;
            }

        }

        [HttpPost]
        public string DanismanFormIslem(IFormCollection collection)
        {

            PageItem item = new PageItem();
            MesajKuyruklar mesajkuyruk = new MesajKuyruklar();
            mesajkuyruk.UygulamaAdi = "AdasoWeb";
            mesajkuyruk.mesajKuyrukTip = "Mail";
            mesajkuyruk.mesajKuyrukAltTip = "danismanForm";
            mesajkuyruk.PersonelAdi = collection["txtadSoyad"];
            mesajkuyruk.PersonelSoyadi = collection["txtadSoyad"];
            mesajkuyruk.PersonelEmail = collection["selectDanismaTipi"];
            mesajkuyruk.baslik = "Adana Sanayi Odası Danışmanımıza Sorun";
            mesajkuyruk.mesajKuyrukBaslik = collection["txtKonu"];
            string cevapTipi = collection["radioEposta"] == "on" ? "Eposta ile cevap almak istiyorum." : collection["radioYazili"] == "on" ? "Yazılı olarak cevap almak istiyorum." : "Cevap Yolu Seçilmedi";
            mesajkuyruk.mesajKuyrukIcerik = "<h3>" + collection["selectBasvuruTipi"] + "</h3><br>" +
                                            "Açıklama&nbsp;&nbsp;&nbsp;:&nbsp;" + collection["textareaAciklama_"] + "<br>" +
                                            "Tc Kimlik&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["txtTCKN"] + "<br>" +
                                            "Ünvan&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["txtFirmaUnvan"] + "<br>" +
                                            "E posta&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["txtEposta"] + "<br>" +
                                            "Adres&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["txtAdres"] + "<br>" +
                                            "Cevap Yolu&nbsp;&nbsp;&nbsp;: &nbsp; " + cevapTipi + "<br>";



            mesajkuyruk.mesajKuyrukDosyaOlTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukDosyaGonTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukGonderildiMi = false;

            var response = Request.Form["g-recaptcha-response"];
            const string secret = "6Lf3QFcdAAAAAK3pgApPgxyRJDMFiEgEiAB_Z7ff";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (!captchaResponse.Success)
            {

                return "Hata|Lütfen Güvenliğinizi Doğrulayınız.";
            }
            else
            {
                var result = _apiCall.Post<List<MesajKuyruklar>>("MesajKuyruklar", $"Add", mesajkuyruk);

                return MessageHelper.SuccessMessage;
            }

        }

        [HttpPost]
        public string BultenAboneIslemler(IFormCollection collection)
        {

            if (string.IsNullOrEmpty(collection["email"]))
            {
                return "Hata|Email Adresi Boş geçilemez";
            }

            PageItem item = new PageItem();
            MesajKuyruklar mesajkuyruk = new MesajKuyruklar();
            mesajkuyruk.UygulamaAdi = "AdasoWeb";
            mesajkuyruk.mesajKuyrukTip = "Mail";
            mesajkuyruk.mesajKuyrukAltTip = "BultenAboneIslemlerForm";
            mesajkuyruk.PersonelAdi = "Yazi";
            mesajkuyruk.PersonelSoyadi = "İşleri";
            mesajkuyruk.PersonelEmail = "yazi@adaso.org.tr";
            mesajkuyruk.baslik = "Adana Sanayi Odası Bülten Talep";
            mesajkuyruk.mesajKuyrukBaslik = "Adana Sanayi Odası Bülten Talep";

            mesajkuyruk.mesajKuyrukIcerik = "<h3>Merhaba Bilgilendirme için mail havuzunuza kayıt edebilir misiniz? </h3><br>" +
                                            "E posta&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;: &nbsp; " + collection["email"] + "<br>";


            mesajkuyruk.mesajKuyrukDosyaOlTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukDosyaGonTarih = DateTime.Now;
            mesajkuyruk.mesajKuyrukGonderildiMi = false;

            var response = Request.Form["g-Recaptcha-Response"];
            const string secret = "6Lf3QFcdAAAAAK3pgApPgxyRJDMFiEgEiAB_Z7ff";
            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));
            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);


            if (!captchaResponse.Success)
            {
                return "Hata|Lütfen Güvenliğinizi Doğrulayınız.";
            }
            else
            {
                var result = _apiCall.Post<List<MesajKuyruklar>>("MesajKuyruklar", $"Add", mesajkuyruk);

                return MessageHelper.SuccessMessage;
            }

        }
    }
}