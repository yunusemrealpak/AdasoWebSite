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
    public class GazetelerController : Controller
    {
        public IApiCall _apiCall;
        public GazetelerController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult Gazeteler()
        {
            TempData["Gazeteler"] = "active";
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }

            return View();
        }

        public IActionResult GazetelerJson(GazetelerFilter kendotable)
        {
            kendotable.sayi = "";
            var result = _apiCall.Post<List<Gazeteler>>("Gazeteler", $"getallwithpaging", kendotable);

            return Json(new { data = result.Data, total_length = result.DataCount });
        }


        public IActionResult GetGazetelerModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetGazetelerUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.Gazeteler = _apiCall.Get<Gazeteler>("Gazeteler", $"getbyid?gazetelerId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetGazetelerSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Gazeteler>("Gazeteler", $"getbyid?gazetelerId={id}");

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
        public string GetGazetelerIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Gazeteler Gazeteler = new Gazeteler();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string dergiyol = "";
                string DergiKapakImgYol = "";
                string type = collection["type"];
                PageItem item = new PageItem();
                Gazeteler.ID = collection["id"].ToInt();

                if (Gazeteler.ID != 0)
                {
                    islemHrk.tableID = Gazeteler.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Gazeteler>("Gazeteler", $"getbyid?gazetelerId={Gazeteler.ID}");

                    if (SilData != null)
                        result = _apiCall.Post<Gazeteler>("Gazeteler", $"Delete", SilData.Data).Message;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion
                #region Dosya Yükle ve Urlsini ver




                if (fileDosyaUrl.Count > 0)
                {
                    for (int i = 0; i < fileDosyaUrl.Count; i++)
                    {
                        FileInfo fi = new FileInfo(fileDosyaUrl[i].FileName);
                        if (fi.Extension == ".pdf")
                        {
                            dergiyol = FileUploadHelper.ToFileIFromSingleFileUploadKaydet(fileDosyaUrl[i], "wwwroot/Content/Files/dergilerFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                            if (dergiyol.Split("|")[0] == "err") return "Hata|" + " " + dergiyol.Split("|")[1];



                        }
                        else if (fi.Extension == ".jpg")
                        {
                            DergiKapakImgYol = FileUploadHelper.ToFileIFromSingleFileUploadKaydet(fileDosyaUrl[i], "wwwroot/Content/Files/dergilerFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".jpg");
                            if (DergiKapakImgYol.Split("|")[0] == "err") return "Hata|" + " " + dergiyol.Split("|")[1];

                        }
                    }
                }
                #endregion

                #region DergiTanimlari
                Gazeteler.GUID = Guid.NewGuid();
                Gazeteler.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                if (DergiKapakImgYol == "") DergiKapakImgYol = _apiCall.Get<Raporlar>("Gazeteler", $"getbyid?gazetelerId={Gazeteler.ID}").Data.ResimUrl;
                if (dergiyol == "") dergiyol = _apiCall.Get<Raporlar>("Gazeteler", $"getbyid?gazetelerId={Gazeteler.ID}").Data.DosyaUrl;
                Gazeteler.DosyaURL = dergiyol;
                Gazeteler.ResimURL = DergiKapakImgYol;
                Gazeteler.Sayi = collection["sayi"].ToInt();
                Gazeteler.Tarih = DateTime.Parse(collection["tarih"]);
                Gazeteler.Sil = false;
                Gazeteler.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Gazeteler.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Gazeteler>("Gazeteler", $"{process}", Gazeteler).Message;

                    int GazetelerLastID = _apiCall.Get<int>("Gazeteler", $"getmaxid").Data;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Gazeteler.Sayi + " Sayılı Dergi " + process + " yapıldı";
                    islemHrk.tableID = GazetelerLastID;
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
    }
}
