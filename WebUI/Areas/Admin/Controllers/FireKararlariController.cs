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
    public class FireKararlariController : Controller
    {
        public IApiCall _apiCall;
        public FireKararlariController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult FireKararlari()
        {
            TempData["FireKararlari"] = "active";
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
        public IActionResult GetFireKararlariModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetFireKararlariUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.FireKararlari = _apiCall.Get<FireKararlari>("FireKararlari", $"getbyid?FireKararlariId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetFireKararlariSilModal(IFormCollection collection)
        {

            int id = collection["id"].ToInt();
            TempData["id"] = id.ToString();
            return View();
        }

        [HttpPost]
        public string GetFireKararlariIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                FireKararlari FireKararlari = new FireKararlari();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string dosyaYol = "";
                string type = collection["type"];
                string selectMeslekGruplari = collection["selectMeslekGruplari"];
                string aciklama = collection["txtAciklama"];

                PageItem item = new PageItem();
                FireKararlari.ID = collection["id"].ToInt();

                if (FireKararlari.ID != 0)
                {
                    islemHrk.tableID = FireKararlari.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {

                    result = _apiCall.Get<FireKararlari>("FireKararlari", $"deletebyid?id=" + FireKararlari.ID).Message;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;

                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    dosyaYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/FireKararlari/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                else
                    dosyaYol = _apiCall.Get<FireKararlari>("FireKararlari", $"getbyid?fireKararlariId={FireKararlari.ID}").Data.DosyaURL;


                #endregion

                #region FireTanimlari
                FireKararlari.GUID = Guid.NewGuid();
                FireKararlari.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                FireKararlari.MeslekGrubuKodu = selectMeslekGruplari;
                FireKararlari.Aciklama = aciklama;
                FireKararlari.DosyaURL = dosyaYol;
                FireKararlari.Tarih = DateTime.Parse(collection["txtTarih"]);
                FireKararlari.Sil = false;
                FireKararlari.OlusturmaTarihi = DateTime.Now;
                #endregion

                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = FireKararlari.ID > 0 ? "Update" : "Add";
                    result = _apiCall.Post<FireKararlari>("FireKararlari", $"{process}", FireKararlari).Message;
                    int FireKararlariLastID = _apiCall.Get<int>("FireKararlari", $"getmaxid").Data;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + FireKararlari.Aciklama.ToString() + " adında " + process + " yapıldı";
                    islemHrk.tableID = FireKararlariLastID;
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

        public IActionResult FireKararlariJson(FireKararlariFilter kendotable)
        {
            kendotable.Aciklama = "";
            var result = _apiCall.Post<List<FireKararlari>>("FireKararlari", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
    }
}
