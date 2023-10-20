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
    public class ProjelerController : Controller
    {

        public IApiCall _apiCall;
        public ProjelerController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        #region Projeler 
        public IActionResult Projeler()
        {
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            TempData["Projeler"] = "active";
            return View();
        }
        [HttpPost]
        public IActionResult GetProjelerModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetProjelerUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.Projeler = _apiCall.Get<Projeler>("Projeler", $"getbyid?projelerId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetProjelerSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Projeler>("Projeler", $"getbyid?projelerId={id}");
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
        public string GetProjelerIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Projeler Projeler = new Projeler();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                PageItem item = new PageItem();
                Projeler.ID = collection["id"].ToInt();

                if (Projeler.ID != 0)
                {
                    islemHrk.tableID = Projeler.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Projeler>("Projeler", $"getbyid?ProjelerId={Projeler.ID}");

                    if (SilData != null)
                        result = _apiCall.Post<Projeler>("Projeler", $"Delete", SilData.Data).Message;


                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/images/project/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".jpg");
                else
                    HaberImgYol = _apiCall.Get<Projeler>("Projeler", $"getbyid?projelerId={Projeler.ID}").Data.ResimUrl;


                #endregion

                #region ProjeTanimlari
                Projeler.GUID = Guid.NewGuid();
                Projeler.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                Projeler.Durum = collection["selectYaziTipi"].ToInt();
                Projeler.BaslangicTarihi = DateTime.Parse(collection["txtBasTarih"]);
                Projeler.BitisTarihi = DateTime.Parse(collection["txtBitTarih"]);
                Projeler.Baslik = collection["txtBaslik"];
                Projeler.AltBaslik = collection["txtAltBaslik"];
                Projeler.ResimUrl = HaberImgYol;
                Projeler.KucukResimUrl = HaberImgYol;

                Projeler.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") Projeler.Ekleyen = collection["hdnEkleyen"];
                else Projeler.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    Projeler.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else Projeler.EklemeTarihi = DateTime.Now;
                Projeler.Guncelleyen = sesslist.personelAdi;
                Projeler.GuncellemeTarihi = DateTime.Now;


                Projeler.Metin = collection["txtMetin_"];
                Projeler.Sil = false;
                Projeler.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Projeler.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Projeler>("Projeler", $"{process}", Projeler).Message;

                    int ProjelerLastID = _apiCall.Get<int>("Projeler", $"getmaxid").Data;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Projeler.Durum.ToString() + " durumunda " + process + " yapıldı";
                    islemHrk.tableID = ProjelerLastID;
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

        public IActionResult ProjelerJson(YazilarFilter kendotable)
        {
            var result = _apiCall.Post<List<Projeler>>("Projeler", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }

        #endregion
    }
}
