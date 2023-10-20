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
    public class BaglantilarController : Controller
    {
        public IApiCall _apiCall;

        public BaglantilarController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult Baglantilar()
        {
            TempData["Baglantilar"] = "active";
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
        public IActionResult GetBaglantilarModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetBaglantilarUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            item.Baglantilar = _apiCall.Get<Baglantilar>("Baglantilar", $"getbyid?baglantilarId={id}");
            return View(item);
        }

        [HttpPost]
        public IActionResult GetBaglantilarSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Baglantilar>("Baglantilar", $"getbyid?baglantilarId={id}");
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
        public string GetBaglantilarIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Baglantilar Baglantilar = new Baglantilar();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);

                string type = collection["type"];
                PageItem item = new PageItem();
                Baglantilar.ID = collection["id"].ToInt();

                if (Baglantilar.ID != 0)
                {
                    islemHrk.tableID = Baglantilar.ID;
                }

                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Baglantilar>("Baglantilar", $"getbyid?BaglantilarId={Baglantilar.ID}");
                    if (SilData != null)
                        result = _apiCall.Post<Baglantilar>("Baglantilar", $"Delete", SilData.Data).Message;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region ProjeTanimlari

                Baglantilar.GUID = Guid.NewGuid();
                Baglantilar.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                Baglantilar.GrupKodu = collection["selectYaziTipi"].ToInt();
                Baglantilar.Grup = collection["KategoriAdi"];
                Baglantilar.SiraNo = collection["txtSira"].ToInt();
                Baglantilar.Baslik = collection["txtBaslik"];
                Baglantilar.WebAdresi = collection["txtWebAdresi"];
                Baglantilar.YeniPencere = Convert.ToBoolean(collection["chckYeniPencere"]);
                Baglantilar.Sil = false;
                Baglantilar.OlusturmaTarihi = DateTime.Now;

                #endregion

                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Baglantilar.ID > 0 ? "Update" : "Add";
                    result = _apiCall.Post<Baglantilar>("Baglantilar", $"{process}", Baglantilar).Message;
                    int BaglantilarLastID = _apiCall.Get<int>("Baglantilar", $"getmaxid").Data;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Baglantilar.Baslik.ToString() + " adında " + process + " yapıldı";
                    islemHrk.tableID = BaglantilarLastID;
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

        public IActionResult BaglantilarJson(BaglantilarFilter kendotable)
        {
            kendotable.Baslik = "";
            var result = _apiCall.Post<List<Baglantilar>>("Baglantilar", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
    }
}
