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
    public class RaporlarController : Controller
    {
        public IApiCall _apiCall;
        public RaporlarController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }

        public IActionResult Raporlar()
        {
            TempData["Raporlar"] = "active";
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public IActionResult GetRaporFormModal(IFormCollection collections)
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetRaporUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["ID"].ToInt();
            item.Raporlar = _apiCall.Get<Raporlar>("Raporlar", $"getbyid?raporlarId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetRaporSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            string a = id.ToString();
            var result = _apiCall.Get<Raporlar>("Raporlar", $"getbyid?raporlarid={id}");
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
        public string GetRaporIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Raporlar rapor = new Raporlar();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                List<string> AlbumImgYol = new List<string>();
                PageItem item = new PageItem();
                rapor.ID = collection["id"].ToInt();

                if (rapor.ID != 0)
                    islemHrk.tableID = rapor.ID;

                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Raporlar>("Raporlar", $"getbyid?raporlarId={rapor.ID}");


                    if (SilData.Data != null)
                        result = _apiCall.Post<Raporlar>("Raporlar", $"Delete", SilData.Data).Message;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                {

                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/raporlarFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                    if (HaberImgYol.Split("|")[0] == "err") return "Hata|" + HaberImgYol.Split("|")[1];

                }
                else
                    HaberImgYol = _apiCall.Get<Raporlar>("Raporlar", $"getbyid?raporlarId={rapor.ID}").Data.DosyaUrl;

                if (collection.Files.Count > 0 && fileDosyaUrl.Count < 1)
                    AlbumImgYol = FileUploadHelper.ToFileMutipleUploadKaydet(collection.Files, "wwwroot/Content/Files/raporlarFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "");
                #endregion

                #region TebligTanimlari
                rapor.GUID = Guid.NewGuid();
                rapor.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                rapor.Baslik = collection["txtBaslik"];
                rapor.AltBaslik = "0";
                rapor.ResimUrl = "0";
                rapor.KucukResimUrl = "0";
                rapor.Tip = Convert.ToInt32(collection["selectYaziTipi"]);
                rapor.DosyaUrl = HaberImgYol;

                rapor.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") rapor.Ekleyen = collection["hdnEkleyen"];
                else rapor.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    rapor.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else rapor.EklemeTarihi = DateTime.Now;
                rapor.Guncelleyen = sesslist.personelAdi;
                rapor.GuncellemeTarihi = DateTime.Now;


                rapor.Sil = false;
                rapor.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = rapor.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Raporlar>("Raporlar", $"{process}", rapor).Message;

                    int tebligLastID = _apiCall.Get<int>("Raporlar", $"getmaxid").Data;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından" + process + " yapıldı";
                    islemHrk.tableID = tebligLastID;
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

        public IActionResult RaporlarJson(RaporFilter kendotable)
        {
            kendotable.Baslik = "";
            var result = _apiCall.Post<List<Raporlar>>("Raporlar", $"getallwithpaging", kendotable);

            return Json(new { data = result.Data, total_length = result.DataCount });
        }

    }
}
