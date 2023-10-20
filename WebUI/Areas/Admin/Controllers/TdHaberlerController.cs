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
    public class TdHaberlerController : Controller
    {

        public IApiCall _apiCall;
        public TdHaberlerController(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }

        public IActionResult TDHaberler()
        {
            TempData["TdHaberler"] = "active";
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpPost]
        public IActionResult GetTDHaberlerModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetTDHaberlerUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["ID"].ToInt();
            item.TDHaberler = _apiCall.Get<TDHaberler>("TDHaberler", $"getbyid?tDHaberlerId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetTDHaberlerSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<TDHaberler>("TDHaberler", $"getbyid?TDHaberlerId={id}");
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
        public string GetTDHAberIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                TDHaberler TDHaberler = new TDHaberler();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                List<string> AlbumImgYol = new List<string>();
                PageItem item = new PageItem();
                TDHaberler.ID = collection["id"].ToInt();

                if (TDHaberler.ID != 0)
                {
                    islemHrk.tableID = TDHaberler.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var TDHaberlerSilData = _apiCall.Get<TDHaberler>("TDHaberler", $"getbyid?TDHaberlerId={TDHaberler.ID}");


                    if (TDHaberlerSilData != null)
                        result = _apiCall.Post<TDHaberler>("TDHaberler", $"Delete", TDHaberlerSilData.Data).Message;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/tdHaberFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                if (HaberImgYol.Split("|")[0] == "err") return MessageHelper.ErrorMessage + " " + HaberImgYol.Split("|")[1];
                else
                    HaberImgYol = _apiCall.Get<TDHaberler>("TDHaberler", $"getbyid?TDHaberlerId={TDHaberler.ID}").Data.DosyaUrl == null ? "0" : _apiCall.Get<TDHaberler>("TDHaberler", $"getbyid?TDHaberlerId={TDHaberler.ID}").Data.DosyaUrl;

                if (collection.Files.Count > 0 && fileDosyaUrl.Count < 1)
                    AlbumImgYol = FileUploadHelper.ToFileMutipleUploadKaydet(collection.Files, "wwwroot/Content/Files/tdHaberFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "");

                #endregion

                #region TDHaberTanimlari
                TDHaberler.GUID = Guid.NewGuid();
                TDHaberler.Tip = collection["selectYaziTipi"].ToInt();
                TDHaberler.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                TDHaberler.EklemeTarihi = DateTime.Now;
                TDHaberler.Baslik = collection["txtBaslik"];
                TDHaberler.DosyaUrl = HaberImgYol;
                TDHaberler.ResimUrl = HaberImgYol;
                TDHaberler.KucukResimUrl = HaberImgYol;

                TDHaberler.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") TDHaberler.Ekleyen = collection["hdnEkleyen"];
                else TDHaberler.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    TDHaberler.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else TDHaberler.EklemeTarihi = DateTime.Now;
                TDHaberler.Guncelleyen = sesslist.personelAdi;
                TDHaberler.GuncellemeTarihi = DateTime.Now;


                TDHaberler.Sil = false;
                TDHaberler.OlusturmaTarihi = DateTime.Now;
                #endregion

                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = TDHaberler.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<TDHaberler>("TDHaberler", $"{process}", TDHaberler).Message;

                    int yazilarLastID = _apiCall.Get<int>("TDHaberler", $"getmaxid").Data;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + TDHaberler.Tip.ToString() + " tipinde " + process + " yapıldı";
                    islemHrk.tableID = yazilarLastID;
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
        public IActionResult TDHaberlerJson(YazilarFilter kendotable)
        {
            kendotable.Baslik = "";
            var result = _apiCall.Post<List<TDHaberler>>("TDHaberler", $"getallwithpaging", kendotable);

            return Json(new { data = result.Data, total_length = result.DataCount });
        }
    }
}
