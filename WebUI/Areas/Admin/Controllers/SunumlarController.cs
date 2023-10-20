using Entities.Dtos.Filter;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SunumlarController : Controller
    {

        public IApiCall _apiCall;

        public SunumlarController(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }
        public IActionResult Sunumlar()
        {
            TempData["Sunumlar"] = "active";
            TempData["HizliIkon"] = "active";
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public IActionResult GetSunumlarModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetSunumlarUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.Sunumlar = _apiCall.Get<Sunumlar>("Sunumlar", $"getbyid?sunumlarId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetSunumlarSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Sunumlar>("Sunumlar", $"getbyid?SunumlarId={id}");
            if (result.Success)
            {
                return View(result);
            }
            else
            {
                return null;
            }
        }

        [HttpPost]
        public string GetSunumlarIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Sunumlar Sunumlar = new Sunumlar();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string Dosyayol = "";

                string type = collection["type"];
                PageItem item = new PageItem();
                Sunumlar.ID = collection["id"].ToInt();

                if (Sunumlar.ID != 0)
                {
                    islemHrk.tableID = Sunumlar.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Sunumlar>("Sunumlar", $"getbyid?sunumlarId={Sunumlar.ID}");

                    if (SilData != null)
                        result = _apiCall.Post<Sunumlar>("Sunumlar", $"Delete", SilData.Data).Message;


                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (collection["txtSunumURL"] == "0")
                {
                    if (fileDosyaUrl.Count > 0)
                        Dosyayol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/Sunumlar/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                    else
                        Dosyayol = _apiCall.Get<Sunumlar>("Sunumlar", $"getbyid?sunumlarId={Sunumlar.ID}").Data.DosyaURL;
                }
                else
                {
                    Dosyayol = collection["txtSunumURL"];
                }

                #endregion


                #region SunumTanimlari
                Sunumlar.Baslik = collection["txtBaslik"];
                Sunumlar.AnaBaslik = collection["txtAnaBaslik"];
                Sunumlar.DosyaURL = Dosyayol;
                Sunumlar.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                Sunumlar.Metin = collection["txtMetin_"];
                Sunumlar.Hazirlayan = collection["txtHazirlayan"];
                Sunumlar.SunumTarihi = DateTime.Parse(collection["txtSunumTarih"]);
                Sunumlar.Guncelleyen = islemHrk.IslemiYapan;
                Sunumlar.GuncellemeTarihi = DateTime.Now;
                Sunumlar.Ekleyen = islemHrk.IslemiYapan;
                Sunumlar.EklemeTarihi = DateTime.Now;
                #endregion

                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Sunumlar.ID > 0 ? "Update" : "Add";
                    result = _apiCall.Post<Sunumlar>("Sunumlar", $"{process}", Sunumlar).Message;
                    int SunumlarLastID = _apiCall.Get<int>("Sunumlar", $"getmaxid").Data;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Sunumlar.Baslik.ToString() + " adında " + process + " yapıldı";
                    islemHrk.tableID = SunumlarLastID;
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;

                }
                #endregion
                return MessageHelper.SuccessMessage;
            }
            catch (Exception ex)
            {
                return MessageHelper.ErrorMessage + " " + ex.Message;
            }
        }

        public IActionResult SunumlarJson(SunumlarFilter kendotable)
        {
            kendotable.Baslik = "";
            var result = _apiCall.Post<List<Sunumlar>>("Sunumlar", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
    }
}
