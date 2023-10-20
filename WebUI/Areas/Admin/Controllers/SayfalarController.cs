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
    public class SayfalarController : Controller
    {
        public IApiCall _apiCall;
        public SayfalarController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult Sayfalar()
        {
            TempData["Sayfalar"] = "active";

            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Admin");
            }
            return View();

        }

        [HttpPost]
        public IActionResult GetSayfalarModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.SayfalarTumliste = _apiCall.Get<List<Sayfalar>>("Sayfalar", $"getall");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetSayfalarUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.SayfalarTumliste = _apiCall.Get<List<Sayfalar>>("Sayfalar", $"getall");
            item.Sayfalar = _apiCall.Get<Sayfalar>("Sayfalar", $"getbyid?sayfalarId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetSayfalarSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Sayfalar>("Sayfalar", $"getbyid?SayfalarId={id}");
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
        public string GetSayfalarIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Sayfalar Sayfalar = new Sayfalar();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);

                string dosyaYol = "";
                string type = collection["type"];
                PageItem item = new PageItem();
                Sayfalar.ID = collection["id"].ToInt();

                if (Sayfalar.ID != 0)
                {
                    islemHrk.tableID = Sayfalar.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Sayfalar>("Sayfalar", $"getbyid?SayfalarId={Sayfalar.ID}");

                    if (SilData != null)
                        result = _apiCall.Post<Sayfalar>("Sayfalar", $"Delete", SilData.Data).Message;


                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion
                //değieşcek
                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    dosyaYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/sayfalarFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".jpg");
                else
                    try { dosyaYol = _apiCall.Get<Sayfalar>("Sayfalar", $"getbyid?sayfalarId={Sayfalar.ID}").Data.DosyaUrl; } catch { dosyaYol = "0"; }
                if (dosyaYol == "")
                    dosyaYol = "0";

                #endregion

                #region ProjeTanimlari
                Sayfalar.GUID = Guid.NewGuid();
                Sayfalar.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                Sayfalar.Dil = "TR";
                Sayfalar.UstID = collection["selectYaziTipi"].ToInt();
                Sayfalar.Duzey = collection["selectYaziTipi"].ToInt();
                Sayfalar.SiraNo = collection["txtSira"].ToInt();
                Sayfalar.Baslik = collection["txtBaslik"];
                Sayfalar.SayfaURL = collection["txtSayfaUrl"];
                Sayfalar.etkin_ = "0";
                Sayfalar.strID = "0";
                if (string.IsNullOrEmpty(collection["txtMetin_"]))
                    Sayfalar.Metin = "&nbsp;";
                else
                    Sayfalar.Metin = collection["txtMetin_"];

                Sayfalar.DosyaUrl = dosyaYol == null ? "0" : dosyaYol;
                Sayfalar.Icerik1 = collection["selectPartialTipi1"];
                Sayfalar.Icerik2 = collection["selectPartialTipi2"];
                Sayfalar.Icerik3 = collection["selectPartialTipi3"];

                Sayfalar.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") Sayfalar.Ekleyen = collection["hdnEkleyen"];
                else Sayfalar.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    Sayfalar.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else Sayfalar.EklemeTarihi = DateTime.Now;
                Sayfalar.Guncelleyen = sesslist.personelAdi;
                Sayfalar.GuncellemeTarihi = DateTime.Now;


                Sayfalar.Sil = false;
                Sayfalar.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Sayfalar.ID > 0 ? "Update" : "Add";
                    result = _apiCall.Post<Sayfalar>("Sayfalar", $"{process}", Sayfalar).Message;

                    int SayfalarLastID = _apiCall.Get<int>("Sayfalar", $"getmaxid").Data;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Sayfalar.Baslik.ToString() + " adında " + process + " yapıldı";
                    islemHrk.tableID = SayfalarLastID;

                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;

                }
                #endregion
                return "Ok|" + Sayfalar.ID;
            }
            catch (Exception ex)
            {
                return MessageHelper.ErrorMessage + " " + ex.Message;
            }
        }

        public IActionResult SayfalarJson(SayfalarFilter kendotable)
        {
            kendotable.Baslik = "";
            var result = _apiCall.Post<List<Sayfalar>>("Sayfalar", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
    }
}