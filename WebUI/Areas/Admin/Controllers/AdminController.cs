using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Entities.Dtos.Filter;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {

        public IApiCall _apiCall;
        public AdminController(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }

        public IActionResult Index()
        {

            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {

                HttpContext.Session.Clear();
                Response.Redirect("admin/admin/login");
            }
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        #region Tebigler

        public IActionResult Tebligler()
        {
            return View();
        }

        [LogAspect(typeof(DatabaseLogger))]
        public IActionResult TebliglerJson(int page, int pageSize, int skip, int take, string baslik)
        {
            var result = _apiCall.Get<List<Yazilar>>("Duyurular", $"getallwithpaging?skip={skip}&take={take}&baslik={baslik}");
            if (result.Success)
            {
                return Json(new { data = result.Data, total_length = result.DataCount });
            }
            return Json("");
        }
        #endregion

        #region Yazilar
        public IActionResult Yazilar()
        {

            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            TempData["Yazilar"] = "active";
            return View();
        }
        [HttpPost]
        public IActionResult GetHaberlerModal(IFormCollection collection)
        {

            return View();
        }

        [HttpPost]
        public IActionResult GetIslemHrkModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();
            var islemHrk = _apiCall.Get<List<IslemGecmisHareketleri>>("islemGecmisHareketleri", $"getTableList?id={id}");
            return View(islemHrk);
        }

        [HttpPost]
        public IActionResult GetHaberlerUpdateModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["ID"].ToInt();
            item.Haberler = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={id}");
            string albumguID = item.Haberler.Data.GUID.ToString();
            item.albumGorselleri = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumguID}");
            return View(item);
        }

        [HttpPost]
        public string GetYaziIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Yazilar yazilar = new Yazilar();
                Albumler Albumler = new Albumler();
                AlbumGorselleri AlbumGorselleri = new AlbumGorselleri();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();

                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                bool popup = Convert.ToBoolean(collection["chckPopup"]);

                List<string> AlbumImgYol = new List<string>();
                PageItem item = new PageItem();
                yazilar.ID = collection["id"].ToInt();
                string albumGUID = "";
                if (yazilar.ID != 0)
                {
                    albumGUID = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={yazilar.ID}").Data.AlbumGUID.ToString();
                    islemHrk.tableID = yazilar.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var yazilarSilData = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={yazilar.ID}");
                    var AlbumlerSilData = _apiCall.Get<Albumler>("Albumler", $"GetAlbumlerGUID?id={albumGUID}");
                    var albumGorselleriSilData = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumGUID}").Data.FirstOrDefault();

                    if (yazilarSilData != null)
                        result = _apiCall.Post<Yazilar>("Yazilar", $"Delete", yazilarSilData.Data).Message;
                    if (AlbumlerSilData != null)
                        result = _apiCall.Post<Albumler>("Albumler", $"Delete", AlbumlerSilData.Data).Message;
                    if (albumGorselleriSilData != null)
                        result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Delete", albumGorselleriSilData).Message;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/images/banner/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".jpg");
                if (HaberImgYol.Split("|")[0] == "err")
                {

                    return "Hata|" + HaberImgYol.Split("|")[1];
                }

                else if (HaberImgYol == "")
                {
                    try { HaberImgYol = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={yazilar.ID}").Data.ResimUrl; } catch { HaberImgYol = "0"; }
                    if (HaberImgYol == "")
                        HaberImgYol = "0";

                }

                if (collection.Files.Count > 0)
                    AlbumImgYol = FileUploadHelper.ToFileMutipleUploadKaydet(collection.Files, "wwwroot/Content/images/gallery/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "");
                else
                    item.albumGorselleri = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumGUID}");

                #endregion

                #region YaziTanimlari
                yazilar.GUID = Guid.NewGuid();
                yazilar.Grup = collection["selectYaziTipi"].ToInt();
                yazilar.AlbumGUID = yazilar.GUID;
                yazilar.Tip = 1;
                yazilar.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                yazilar.BaslangicTarihi = DateTime.Parse(collection["txtBasTarih"]);
                yazilar.BitisTarihi = DateTime.Parse(collection["txtBitTarih"]);
                yazilar.Baslik = collection["txtBaslik"];
                yazilar.AltBaslik = collection["txtAltBaslik"];
                yazilar.ResimUrl = HaberImgYol;
                yazilar.KucukResimUrl = HaberImgYol;
                yazilar.Popup = popup;
                yazilar.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") yazilar.Ekleyen = collection["hdnEkleyen"];
                else yazilar.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    yazilar.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else yazilar.EklemeTarihi = DateTime.Now;
                yazilar.Guncelleyen = sesslist.personelAdi;
                yazilar.GuncellemeTarihi = DateTime.Now;

                if (string.IsNullOrEmpty(collection["txtMetin_"]))
                    yazilar.Metin = "&nbsp;";
                else
                    yazilar.Metin = collection["txtMetin_"];

                yazilar.KategoriAdi = collection["KategoriAdi"];
                yazilar.Sil = false;
                yazilar.OlusturmaTarihi = DateTime.Now;
                #endregion

                #region AlbumTanimlari
                Albumler.GUID = yazilar.GUID;
                Albumler.Etkin = true;
                Albumler.Tarih = DateTime.Now;
                Albumler.Ad = collection["txtBaslik"];
                Albumler.KucukResimURL = HaberImgYol;
                Albumler.ResimSayisi = collection.Files.Count;
                #endregion

                #region AlbumGorselleriTanimi
                AlbumGorselleri.AlbumGUID = Albumler.GUID;
                AlbumGorselleri.Aciklama = collection["txtBaslik"];
                AlbumGorselleri.OlusturmaTarihi = DateTime.Now;
                AlbumGorselleri.Sira = 0;


                #endregion

                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = yazilar.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Yazilar>("Yazilar", $"{process}", yazilar).Message;
                    int yazilarLastID = _apiCall.Get<int>("Yazilar", $"getmaxid").Data;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + yazilar.Tip.ToString() + " tipinde " + process + " yapıldı";
                    islemHrk.tableID = yazilarLastID;
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;

                    if (process == "Update")
                    {
                        if (_apiCall.Get<Albumler>("Albumler", $"GetAlbumlerGUID?id={albumGUID}").DataCount > 0)
                        {
                            Albumler.ID = _apiCall.Get<Albumler>("Albumler", $"GetAlbumlerGUID?id={albumGUID}").Data.ID;
                            result = _apiCall.Post<Albumler>("Albumler", $"Update", Albumler).Message;
                        }
                        else
                        {
                            result = _apiCall.Post<Albumler>("Albumler", $"Add", Albumler).Message;
                        }
                    }
                    else
                        result = _apiCall.Post<Albumler>("Albumler", $"{process}", Albumler).Message;

                    if (item.albumGorselleri == null)
                    {
                        foreach (var albumUpdate in item.albumGorselleri.Data)
                        {
                            AlbumGorselleri.ResimURL = albumUpdate.ResimURL;
                            AlbumGorselleri.KucukResimURL = albumUpdate.KucukResimURL;
                            result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Update", AlbumGorselleri).Message;

                        }
                    }
                    else
                    {
                        if (AlbumImgYol.Count > 0)
                        {
                            foreach (var resimUrl in AlbumImgYol)
                            {
                                AlbumGorselleri.ResimURL = resimUrl;
                                AlbumGorselleri.KucukResimURL = resimUrl;
                                result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Add", AlbumGorselleri).Message;
                            }
                        }
                        else
                        {
                            foreach (var resimUrl in item.albumGorselleri.Data)
                            {
                                AlbumGorselleri.ID = resimUrl.ID;
                                AlbumGorselleri.ResimURL = resimUrl.ResimURL;
                                AlbumGorselleri.KucukResimURL = resimUrl.ResimURL;
                                result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Update", AlbumGorselleri).Message;
                            }

                            string ImgSira = collection["ImgSira"];
                            string ImgIDwithOrder = "";
                            if (ImgSira == "null_") AlbumGorselleri.Sira = 0;
                            #region AlbumSirala
                            else if (ImgSira != "null_")
                            {
                                for (int i = 0; i < ImgSira.Split(',').Length; i++)
                                {
                                    if (i == 0)
                                        ImgIDwithOrder = ImgSira.Split(',')[i].Replace("null_", "");
                                    else
                                        ImgIDwithOrder = ImgSira.Split(',')[i];
                                    int gorselID = ImgIDwithOrder.Split('-')[1].ToInt();
                                    AlbumGorselleri AlbumGorselleri_ = _apiCall.Get<AlbumGorselleri>("AlbumGorselleri", $"getbyid?albumGorselleriId={gorselID}").Data;
                                    AlbumGorselleri_.Sira = ImgIDwithOrder.Split('-')[0].ToInt();

                                    result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Update", AlbumGorselleri_).Message;
                                }
                            }
                            #endregion
                        }
                    }
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
        public IActionResult GetYazilarSilModal(IFormCollection collection)
        {
            int id = collection["ID"].ToInt();
            var result = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={id}");
            if (result.Success)
            {
                return View(result);
            }
            else
            {
                return null;
            }
        }
        public IActionResult YazilarJson(YazilarFilter kendotable)
        {
            var result = _apiCall.Post<List<Yazilar>>("Yazilar", $"getallwithpaging", kendotable);

            return Json(new { data = result.Data, total_length = result.DataCount });
        }

        #endregion

        #region Logins
        public IActionResult Login(IFormCollection collection)
        {


            return View();
        }
        public RedirectResult Logout(IFormCollection collection)
        {
            HttpContext.Session.Clear();
            return Redirect("/admin/admin/login");
        }

        [HttpPost]
        public string GetLoginForm(IFormCollection collection)
        {
            string email = collection["email"];
            string password = collection["password"];

            var response = Helper.UserHelper.UserLogin(email, password);
            var result = JsonConvert.DeserializeObject<string>(response);
            var result_ = JsonConvert.DeserializeObject<LoginResult>(result);

            HttpContext.Session.SetString("SessionList", JsonConvert.SerializeObject(result_));

            var sess = HttpContext.Session.GetString("SessionList");
            var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);

            int personelID = sesslist.personelID;


            if (personelID > 0)
            {

                return "Ok|/admin/admin/yazilar";

            }
            else
            {
                HttpContext.Session.Clear();
                return "Hata|" + result_.messageDescription;
            }
        }
        #endregion

        #region FileManager
        public IActionResult FileManager()
        {

            var sess = HttpContext.Session.GetString("SessionList");
            if (sess == null)
            {
                HttpContext.Session.Clear();

                return RedirectToAction("Login", "Admin");
            }
            TempData["FileManager"] = "active";
            return View();
        }

        [HttpPost]
        public string FileManagerIslemler(IFormCollection collection, List<IFormFile> fileDosyaUrl)
        {
            try
            {
                #region Tanımlamalar
                string result = "";
                Yazilar yazilar = new Yazilar();
                Albumler Albumler = new Albumler();
                AlbumGorselleri AlbumGorselleri = new AlbumGorselleri();
                IslemGecmisHareketleri islemHrk = new IslemGecmisHareketleri();

                var sess = HttpContext.Session.GetString("SessionList");
                var sesslist = JsonConvert.DeserializeObject<LoginResult>(sess);
                string HaberImgYol = "";
                string type = collection["type"];
                List<string> AlbumImgYol = new List<string>();
                PageItem item = new PageItem();
                yazilar.ID = collection["id"].ToInt();
                string albumGUID = "";
                if (yazilar.ID != 0)
                {
                    albumGUID = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={yazilar.ID}").Data.AlbumGUID.ToString();
                    islemHrk.tableID = yazilar.ID;
                }
                islemHrk.GUID = Guid.NewGuid();
                islemHrk.IslemiYapan = sesslist.personelAdi + " " + sesslist.personelSoyadi;
                islemHrk.IslemTarihi = DateTime.Now;
                islemHrk.Konum = "89.252.153.143";

                #endregion

                #region Sil
                if (type == "Sil")
                {
                    var yazilarSilData = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={yazilar.ID}");
                    var AlbumlerSilData = _apiCall.Get<Albumler>("Albumler", $"GetAlbumlerGUID?id={albumGUID}");
                    var albumGorselleriSilData = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumGUID}").Data.FirstOrDefault();

                    if (yazilarSilData != null)
                        result = _apiCall.Post<Yazilar>("Yazilar", $"Delete", yazilarSilData.Data).Message;
                    if (AlbumlerSilData != null)
                        result = _apiCall.Post<Albumler>("Albumler", $"Delete", AlbumlerSilData.Data).Message;
                    if (albumGorselleriSilData != null)
                        result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Delete", albumGorselleriSilData).Message;
                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından silme yapıldı";
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;
                    return MessageHelper.SuccessMessage;
                }
                #endregion

                #region Dosya Yükle ve Urlsini ver
                if (fileDosyaUrl.Count > 0)
                    HaberImgYol = FileUploadHelper.ToFileIFromFileUploadKaydet(fileDosyaUrl, "wwwroot/Content/images/banner/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "", ".jpg");
                if (HaberImgYol.Split("|")[0] == "err")
                {

                    return "Hata|" + HaberImgYol.Split("|")[1];
                }

                else if (HaberImgYol == "")
                {
                    try { HaberImgYol = _apiCall.Get<Yazilar>("Yazilar", $"getbyid?YazilarId={yazilar.ID}").Data.ResimUrl; } catch { HaberImgYol = "0"; }
                    if (HaberImgYol == "")
                        HaberImgYol = "0";

                }

                if (collection.Files.Count > 0)
                    AlbumImgYol = FileUploadHelper.ToFileMutipleUploadKaydet(collection.Files, "wwwroot/Content/images/gallery/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/", "");
                else
                    item.albumGorselleri = _apiCall.Get<List<AlbumGorselleri>>("AlbumGorselleri", $"getbyGuID?ID={albumGUID}");

                #endregion

                #region YaziTanimlari
                yazilar.GUID = Guid.NewGuid();
                yazilar.Grup = collection["selectYaziTipi"].ToInt();
                yazilar.AlbumGUID = yazilar.GUID;
                yazilar.Tip = 1;
                yazilar.Etkin = Convert.ToBoolean(collection["chckEtkin"]);
                yazilar.BaslangicTarihi = DateTime.Parse(collection["txtBasTarih"]);
                yazilar.BitisTarihi = DateTime.Parse(collection["txtBitTarih"]);
                yazilar.Baslik = collection["txtBaslik"];
                yazilar.AltBaslik = collection["txtAltBaslik"];
                yazilar.ResimUrl = HaberImgYol;
                yazilar.KucukResimUrl = HaberImgYol;

                yazilar.GosterimSayisi = collection["hdnGosterimSayisi"].ToInt();
                if (collection["hdnEkleyen"] != "0") yazilar.Ekleyen = collection["hdnEkleyen"];
                else yazilar.Ekleyen = sesslist.personelAdi;
                if (collection["hdnEklemeTarihi"] != "0")
                    yazilar.EklemeTarihi = DateTime.Parse(collection["hdnEklemeTarihi"]);
                else yazilar.EklemeTarihi = DateTime.Now;
                yazilar.Guncelleyen = sesslist.personelAdi;
                yazilar.GuncellemeTarihi = DateTime.Now;

                if (string.IsNullOrEmpty(collection["txtMetin_"]))
                    yazilar.Metin = "&nbsp;";
                else
                    yazilar.Metin = collection["txtMetin_"];

                yazilar.KategoriAdi = collection["KategoriAdi"];
                yazilar.Sil = false;
                yazilar.OlusturmaTarihi = DateTime.Now;
                #endregion

                #region AlbumTanimlari
                Albumler.GUID = yazilar.GUID;
                Albumler.Etkin = true;
                Albumler.Tarih = DateTime.Now;
                Albumler.Ad = collection["txtBaslik"];
                Albumler.KucukResimURL = HaberImgYol;
                Albumler.ResimSayisi = collection.Files.Count;
                #endregion

                #region AlbumGorselleriTanimi
                AlbumGorselleri.AlbumGUID = Albumler.GUID;
                AlbumGorselleri.Aciklama = collection["txtBaslik"];
                AlbumGorselleri.OlusturmaTarihi = DateTime.Now;
                #endregion

                #region Kaydet
                if (type == "Kaydet")
                {
                    string process = yazilar.ID > 0 ? "Update" : "Add";

                    result = _apiCall.Post<Yazilar>("Yazilar", $"{process}", yazilar).Message;

                    int yazilarLastID = _apiCall.Get<int>("Yazilar", $"getmaxid").Data;

                    islemHrk.Aciklama = sesslist.personelID.ToString() + "Id li kullanıcı tarafından " + yazilar.Tip.ToString() + " tipinde " + process + " yapıldı";
                    islemHrk.tableID = yazilarLastID;
                    result = _apiCall.Post<IslemGecmisHareketleri>("IslemGecmisHareketleri", $"add", islemHrk).Message;

                    if (process == "Update")
                    {
                        if (_apiCall.Get<Albumler>("Albumler", $"GetAlbumlerGUID?id={albumGUID}").DataCount > 0)
                        {
                            Albumler.ID = _apiCall.Get<Albumler>("Albumler", $"GetAlbumlerGUID?id={albumGUID}").Data.ID;
                            result = _apiCall.Post<Albumler>("Albumler", $"Update", Albumler).Message;
                            result = _apiCall.Post<Albumler>("Albumler", $"Update", Albumler).Message;
                        }
                        else
                        {
                            result = _apiCall.Post<Albumler>("Albumler", $"Add", Albumler).Message;
                            result = _apiCall.Post<Albumler>("Albumler", $"Add", Albumler).Message;
                        }
                    }
                    else
                        result = _apiCall.Post<Albumler>("Albumler", $"{process}", Albumler).Message;

                    if (item.albumGorselleri == null)
                    {
                        foreach (var albumUpdate in item.albumGorselleri.Data)
                        {
                            AlbumGorselleri.ResimURL = albumUpdate.ResimURL;
                            AlbumGorselleri.KucukResimURL = albumUpdate.KucukResimURL;
                            result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Update", AlbumGorselleri).Message;
                        }
                    }
                    else
                    {
                        if (AlbumImgYol.Count > 0)
                        {
                            foreach (var resimUrl in AlbumImgYol)
                            {
                                AlbumGorselleri.ResimURL = resimUrl;
                                AlbumGorselleri.KucukResimURL = resimUrl;
                                result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Add", AlbumGorselleri).Message;
                            }
                        }
                        else
                        {
                            foreach (var resimUrl in item.albumGorselleri.Data)
                            {
                                AlbumGorselleri.ResimURL = resimUrl.ResimURL;
                                AlbumGorselleri.KucukResimURL = resimUrl.ResimURL;
                                result = _apiCall.Post<AlbumGorselleri>("AlbumGorselleri", $"Add", AlbumGorselleri).Message;
                            }
                        }

                    }
                }
                #endregion

                return MessageHelper.SuccessMessage;
            }
            catch (Exception ex)
            {
                return MessageHelper.ErrorMessage + " " + ex.Message;
            }
        }

        public IActionResult FileManagerJson(DosyaYonetimiFilter kendotable)
        {
            var result = _apiCall.Post<List<DosyaYonetimi>>("DosyaYonetimi", $"getallwithpaging", kendotable);

            return Json(new { data = result.Data, total_length = result.DataCount });

        }


        public IActionResult GetDosyaYonetimiModal(IFormCollection collection)
        {
            PageItem item = new PageItem();
            int id = collection["id"].ToInt();

            return View(item);
        }
        [HttpPost]
        public string GetDosyaYonetimiCopy(IFormCollection collection)
        {
            string result = "";
            int id = collection["id"].ToInt();

            DosyaYonetimi dosyaYonetimi = _apiCall.Get<DosyaYonetimi>("DosyaYonetimi", $"getbyid?DosyaYonetimiId={id}").Data;

            result = "http://www.adaso.org.tr/" + dosyaYonetimi.FilePath.Trim().Replace("wwwroot/", "") + "/" + dosyaYonetimi.FileName.Trim();

            return "Ok|" + result;
        }
        //private IHostingEnvironment hostingEnv;
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var FileDic = "wwwroot/Content/Files/fileMenager/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/";
            string FilePath = Path.Combine(FileDic);
            FileInfo fileInfo = new FileInfo(file.FileName);
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);

            var fileName = file.FileName;
            var filePath = Path.Combine(FilePath, fileName);
            using (FileStream fs = System.IO.File.Create(filePath))
            {

                file.CopyTo(fs);

                DosyaYonetimi dosyalar = new DosyaYonetimi();
                dosyalar.FileExtension = fileInfo.Extension;
                dosyalar.FileName = fileInfo.Name;
                dosyalar.FilePath = FileDic;
                dosyalar.FileSize = file.Length;
                dosyalar.FileSizeStr = Helper.VariableConvertHelper.ToFileSize(file.Length).ToString();
                dosyalar.Status = true;
                dosyalar.CreateDate = DateTime.Now;

                var result = _apiCall.Post<DosyaYonetimi>("DosyaYonetimi", $"Add", dosyalar).Message;

            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public string GetDosyaYonetimiSilModal(IFormCollection collection)
        {
            int id = collection["id"].ToInt();

            DosyaYonetimi dosyaYonetimi = _apiCall.Get<DosyaYonetimi>("DosyaYonetimi", $"getbyid?DosyaYonetimiId={id}").Data;
            string filepathtable = "/" + dosyaYonetimi.FilePath.Trim() + "/" + dosyaYonetimi.FileName.Trim();
            string path = Environment.CurrentDirectory + filepathtable;
            var result = _apiCall.Get<DosyaYonetimi>("DosyaYonetimi", $"deletebyid?id=" + id).Success;

            if (result == true)
            {
                FileInfo file = new FileInfo(path);
                file.Delete();
            }

            return MessageHelper.SuccessMessage;
        }
        #endregion


        #region GenelArama
        public IActionResult procAdasoOrgTrGenelArama(SearchFilter kendoAutoComplete)
        {
            var result = _apiCall.Post<List<proc_Adaso_org_tr_GenelArama>>("GenelArama", $"getallwithpaging", kendoAutoComplete);
            return Json(new { data = result.Data, total_length = result.DataCount });
        }
        #endregion
    }
}