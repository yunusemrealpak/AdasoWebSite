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
    public class EtkinliklerController : Controller
    {
        public IApiCall _apiCall;

        public EtkinliklerController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult Etkinlikler()
        {
            TempData["Etkinlikler"] = "active";
            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public IActionResult EtkinlikJson(YazilarFilter kendotable)
        {
            kendotable.Baslik = "";
            //var result = _apiCall.Post<List<Etkinlikler>>("Etkinlikler", $"getallwithpaging", kendotable);
            ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>> result = _apiCall.Get<List<View_Base_Hedef_Tekrar_Getir>>("View_Base_Hedef_Tekrar_Getir", $"getall");

            return Json(new { data = result.Data, total_length = result.DataCount });

        }


        public IActionResult GetEtkinliklerModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetEtkinliklerUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["ID"].ToInt();
            item.Etkinlikler = _apiCall.Get<Etkinlikler>("Etkinlikler", $"getbyid?etkinliklerId={id}");
            return View(item);
        }



        [HttpPost]
        public IActionResult GetEtkinliklerSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();
            var result = _apiCall.Get<Etkinlikler>("Etkinlikler", $"getbyid?etkinliklerId={id}");
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
        public string GetEtkinliklerIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Etkinlikler Etkinlikler = new Etkinlikler();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();
                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                PageItem item = new PageItem();
                Etkinlikler.ID = collection["id"].ToInt();

                if (Etkinlikler.ID != 0)
                {
                    islemHrk.tableID = Etkinlikler.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var SilData = _apiCall.Get<Etkinlikler>("Etkinlikler", $"getbyid?etkinliklerId={Etkinlikler.ID}");

                    if (SilData != null)
                        result = _apiCall.Post<Etkinlikler>("Etkinlikler", $"Delete", SilData.Data).Message;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion
                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                {

                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/Files/EtkinliklerFiles/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".pdf");
                    if (HaberImgYol.Split("|")[0] == "err") return "Hata|" + " " + HaberImgYol.Split("|")[1];
                }
                else
                    try { HaberImgYol = _apiCall.Get<Raporlar>("Raporlar", $"getbyid?raporlarId={Etkinlikler.ID}").Data.DosyaUrl; } catch { HaberImgYol = "0"; }

                #endregion

                #region YaziTanimlari
                Etkinlikler.GUID = Guid.NewGuid();
                Etkinlikler.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                Etkinlikler.BaslangicTarihi = DateTime.Parse(collection["txtBasTarih"]);
                Etkinlikler.BitisTarihi = DateTime.Parse(collection["txtBitTarih"]);
                Etkinlikler.Baslik = collection["txtBaslik"];
                if (string.IsNullOrEmpty(collection["txtMetin_"]))
                    Etkinlikler.Metin = "&nbsp;";
                else
                    Etkinlikler.Metin = collection["txtMetin_"];

                Etkinlikler.Yer = collection["txtToplantiYeri"];
                Etkinlikler.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                Etkinlikler.DosyaURL = HaberImgYol;

                Etkinlikler.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") Etkinlikler.Ekleyen = collection["hdnEkleyen"];
                else Etkinlikler.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    Etkinlikler.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else Etkinlikler.EklemeTarihi = DateTime.Now;
                Etkinlikler.Guncelleyen = sesslist.personelAdi;
                Etkinlikler.GuncellemeTarihi = DateTime.Now;



                Etkinlikler.Sil = false;
                Etkinlikler.OlusturmaTarihi = DateTime.Now;
                #endregion


                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = Etkinlikler.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Etkinlikler>("Etkinlikler", $"{process}", Etkinlikler).Message;

                    int EtkinliklerLastID = _apiCall.Get<int>("Etkinlikler", $"getmaxid").Data;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + Etkinlikler.Baslik.ToString() + " başlıklı etkinlik " + process + " yapıldı";
                    islemHrk.tableID = EtkinliklerLastID;
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
