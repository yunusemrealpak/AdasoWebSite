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
    public class YoutubeController : Controller
    {
        public IApiCall _apiCall;


        public YoutubeController(ApiCall apiCall)
        {

            _apiCall = apiCall;
        }
        public IActionResult Youtube()
        {
            TempData["Youtube"] = "active";
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
        public IActionResult GetYoutubeModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetYoutubeUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.Youtube = _apiCall.Get<Youtube>("Youtube", $"getbyid?YoutubeId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetYoutubeSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Youtube>("Youtube", $"getbyid?youtubeId={id}");
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
        public string GetYoutubeIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Youtube Youtube = new Youtube();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string ImgYol = "";

                string type = collection["type"];
                PageItem item = new PageItem();
                Youtube.ID = collection["id"].ToInt();

                if (Youtube.ID != 0)
                {
                    islemHrk.tableID = Youtube.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Youtube>("Youtube", $"getbyid?youtubeId={Youtube.ID}");

                    if (SilData != null)
                        result = _apiCall.Post<Youtube>("Youtube", $"Delete", SilData.Data).Message;


                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    ImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/images/youtube/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".jpg");
                else
                    ImgYol = _apiCall.Get<Youtube>("Youtube", $"getbyid?youtubeId={Youtube.ID}").Data.ResimURL;


                #endregion

                #region ProjeTanimlari
                Youtube.GUID = Guid.NewGuid();
                Youtube.Etkin = Convert.ToBoolean(collection["chckEtkin"]);

                Youtube.Tarih = DateTime.Parse(collection["txtTarih"]);
                Youtube.Baslik = collection["txtBaslik"];
                Youtube.ResimURL = ImgYol;
                Youtube.VideoURL = collection["txtVideoUrl"];
                Youtube.Sira = collection["txtSira"].ToInt();
                Youtube.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();

                Youtube.Sil = false;
                Youtube.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Youtube.ID > 0 ? "Update" : "Add";
                    result = _apiCall.Post<Youtube>("Youtube", $"{process}", Youtube).Message;
                    int YoutubeLastID = _apiCall.Get<int>("Youtube", $"getmaxid").Data;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Youtube.Baslik.ToString() + " adında " + process + " yapıldı";
                    islemHrk.tableID = YoutubeLastID;
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

        public IActionResult YoutubeJson(YoutubeFilter kendotable)
        {
            kendotable.Baslik = "";
            var result = _apiCall.Post<List<Youtube>>("Youtube", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
    }
}
