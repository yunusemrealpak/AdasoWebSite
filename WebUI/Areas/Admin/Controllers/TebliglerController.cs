using Entities.Dtos.Filter;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TebliglerController : Controller
    {


        public IApiCall _apiCall;

        public TebliglerController(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }

        public IActionResult Tebligler()
        {
            TempData["Tebligler"] = "active";
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public IActionResult TebliglerJson(TebliglerFilter kendotable)
        {
            //kendotable.Baslik = "";
            var result = _apiCall.Post<List<Tebligler>>("Tebligler", $"getallwithpaging", kendotable);

            return Json(new { data = result.Data, total_length = result.DataCount });
        }

        #region partial view
        [HttpPost]
        public IActionResult GetTebliglerForm(IFormCollection collection)
        {
            int id = collection["ID"].ToInt();
            var result = _apiCall.Get<Tebligler>("Tebligler", $"getbyid?tebliglerId={id}");
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
        public string GetTebligIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Tebligler tebligler = new Tebligler();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                List<string> AlbumImgYol = new List<string>();
                PageItem item = new PageItem();
                tebligler.ID = collection["id"].ToInt();

                if (tebligler.ID != 0)
                    islemHrk.tableID = tebligler.ID;

                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    result = _apiCall.Get<Tebligler>("Tebligler", $"deletebyid?id={tebligler.ID}").Message;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                {
                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/tebligFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                    if (HaberImgYol.Split("|")[0] == "err") return "Hata|" + HaberImgYol.Split("|")[1];

                }
                else if (HaberImgYol == "")
                {
                    try { HaberImgYol = _apiCall.Get<Tebligler>("Tebligler", $"getbyid?TebliglerId={tebligler.ID}").Data.DosyaUrl; } catch { HaberImgYol = "0"; }
                    if (HaberImgYol == "")
                        HaberImgYol = "0";

                }


                if (collection.Files.Count > 0 && fileDosyaUrl.Count < 1)
                    AlbumImgYol = FileUploadHelper.ToFileMutipleUploadKaydet(collection.Files, "wwwroot/Content/Files/tebligFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "");
                #endregion

                #region TebligTanimlari
                tebligler.GUID = Guid.NewGuid();
                tebligler.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                tebligler.Tarih = DateTime.Parse(collection["txtTarih"]);
                tebligler.Baslik = collection["txtBaslik"];
                tebligler.AltBaslik = collection["txtAltBaslik"];
                tebligler.DosyaUrl = HaberImgYol;

                tebligler.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") tebligler.Ekleyen = collection["hdnEkleyen"];
                else tebligler.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    tebligler.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else tebligler.EklemeTarihi = DateTime.Now;
                tebligler.Guncelleyen = sesslist.personelAdi;
                tebligler.GuncellemeTarihi = DateTime.Now;

                if (string.IsNullOrEmpty(collection["txtMetin_"]))
                    tebligler.Metin = "&nbsp;";
                else
                    tebligler.Metin = collection["txtMetin_"];

                tebligler.Sil = false;
                tebligler.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = tebligler.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Tebligler>("Tebligler", $"{process}", tebligler).Message;

                    int tebligLastID = _apiCall.Get<int>("Tebligler", $"getmaxid").Data;

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

        [HttpPost]
        public IActionResult GetTebliglerUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["ID"].ToInt();
            item.Tebligler = _apiCall.Get<Tebligler>("Tebligler", $"getbyid?tebliglerId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetTebliglerSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Tebligler>("Tebligler", $"getbyid?tebliglerId={id}");
            if (result.Success && result.DataCount > 0)
            {
                return View(result);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region post işlemleri
        [HttpPost]
        public string TebliglerIslem(IFormCollection collection, IFormFile fileDosyaUrl)
        {
            string result = "";
            try
            {
                Tebligler item = new Tebligler();
                string type = collection["type"].ToString();
                if (Convert.ToInt32(collection["ID"]) > 0)
                {
                    item = _apiCall.Get<Tebligler>("Tebligler", $"getbyid?tebliglerId={collection["ID"]}").Data;
                }
                if (type == "Kaydet")
                {
                    item.Baslik = collection["txtBaslik"].ToString();
                    item.AltBaslik = collection["txtAltBaslik"].ToString();
                    item.Metin = collection["txtMetin"].ToString();
                    item.Tarih = Convert.ToDateTime(collection["txtTarih"]);
                    string DosyaUrl = collection["hdnDosyaUrl"].ToString();

                    item.DosyaUrl = ToFileUploadKaydet(fileDosyaUrl, "/Content/Dosyalar/Firma/", DosyaUrl);
                    string process = item.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Tebligler>("Tebligler", $"{process}", item).Message;
                }
                else if (type == "Sil")
                {
                    result = _apiCall.Post<Tebligler>("Tebligler", $"delete", item).Message;
                }
            }
            catch (Exception ex)
            {
                result = MessageHelper.ErrorMessage + " " + ex.Message;
            }
            return result;
        }

        public string ToFileUploadKaydet(IFormFile o, string KlasorYol, string DosyaYol)
        {
            string ExistFolder = "";
            for (int i = 1; i < KlasorYol.Split('/').Length - 1; i++)
            {
                ExistFolder += "/" + KlasorYol.Split('/')[i] + "/";
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ExistFolder)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", ExistFolder));
                }
            }

            IFormFile Fu = (o as IFormFile);
            String FileName = Guid.NewGuid().ToString();
            String FileNameExtension = "";
            try
            {
                if (Fu != null)
                {
                    FileNameExtension = System.IO.Path.GetExtension(Fu.FileName);
                    using (Stream fileStream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", KlasorYol) + FileName + FileNameExtension, FileMode.Create))
                    {
                        Fu.CopyTo(fileStream);
                    }
                    return KlasorYol + FileName + FileNameExtension;
                }
                else
                {
                    return DosyaYol;
                }
            }
            catch
            {
                FileName = "";
                FileNameExtension = "";
                return DosyaYol;
            }
        }
        #endregion
    }
}