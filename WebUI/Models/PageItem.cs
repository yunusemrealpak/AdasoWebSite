using System.Collections.Generic;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.Models
{
    public class PageItem
    {
        public ResponseMessage<List<Yazilar>> sliders = new ResponseMessage<List<Yazilar>>();

        public List<Organizasyon> organizations = new List<Organizasyon>();

        public ResponseMessage<Yazilar> Haberler = new ResponseMessage<Yazilar>();

        public ResponseMessage<Projeler> Projeler = new ResponseMessage<Projeler>();

        public ResponseMessage<Tebligler> Tebligler = new ResponseMessage<Tebligler>();

        public ResponseMessage<Youtube> Youtube = new ResponseMessage<Youtube>();

        public ResponseMessage<Baglantilar> Baglantilar = new ResponseMessage<Baglantilar>();

        public ResponseMessage<FireKararlari> FireKararlari = new ResponseMessage<FireKararlari>();

        public ResponseMessage<List<Youtube>> YoutubeList = new ResponseMessage<List<Youtube>>();

        public ResponseMessage<Etkinlikler> Etkinlikler = new ResponseMessage<Etkinlikler>();

        public ResponseMessage<view_Uye_Bilgileri> viewUyeBilgileri = new ResponseMessage<view_Uye_Bilgileri>();

        public ResponseMessage<List<view_Temsilciler>> view_Temsilciler_list = new ResponseMessage<List<view_Temsilciler>>();

        public ResponseMessage<List<view_ortaklik>> view_ortaklik_list = new ResponseMessage<List<view_ortaklik>>();

        public ResponseMessage<List<view_UyeUyelikSabitTelefon>> view_UyeUyelikSabitTelefon = new ResponseMessage<List<view_UyeUyelikSabitTelefon>>();

        public ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>> View_Base_Hedef_Tekrar_Getir_List = new ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>>();

        public ResponseMessage<View_Base_Hedef_Tekrar_Getir> View_Base_Hedef_Tekrar_Getir = new ResponseMessage<View_Base_Hedef_Tekrar_Getir>();

        public ResponseMessage<Sayfalar> Sayfalar = new ResponseMessage<Sayfalar>();

        public ResponseMessage<List<Sayfalar>> SayfalarTumliste = new ResponseMessage<List<Sayfalar>>();

        public ResponseMessage<List<view_Sayfalar>> GetListPageTitle = new ResponseMessage<List<view_Sayfalar>>();

        public ResponseMessage<DosyaYonetimi> DosyaYonetimi = new ResponseMessage<DosyaYonetimi>();

        public ResponseMessage<Gazeteler> Gazeteler = new ResponseMessage<Gazeteler>();

        public ResponseMessage<List<Gazeteler>> GazetelerList = new ResponseMessage<List<Gazeteler>>();

        public ResponseMessage<Raporlar> Raporlar = new ResponseMessage<Raporlar>();

        public ResponseMessage<List<Sunumlar>> SunumlarList = new ResponseMessage<List<Sunumlar>>();

        public ResponseMessage<List<Crs_Sunumlar_Sonuc>> SunumlarSonucList = new ResponseMessage<List<Crs_Sunumlar_Sonuc>>();

        public ResponseMessage<Sunumlar> Sunumlar = new ResponseMessage<Sunumlar>();

        public ResponseMessage<TDHaberler> TDHaberler = new ResponseMessage<TDHaberler>();

        public ResponseMessage<Yazilar> popup = new ResponseMessage<Yazilar>();

        public ResponseMessage<List<IslemGecmisHareketleri>> islemHrk = new ResponseMessage<List<IslemGecmisHareketleri>>();

        public ResponseMessage<List<AlbumGorselleri>> albumGorselleri = new ResponseMessage<List<AlbumGorselleri>>();

        public ResponseMessage<List<Albumler>> albumler = new ResponseMessage<List<Albumler>>();

        public ResponseMessage<List<Yazilar>> Duyurular = new ResponseMessage<List<Yazilar>>();

        public ResponseMessage<List<DuyurularUI>> UstDuyurular = new ResponseMessage<List<DuyurularUI>>();

        public ResponseMessage<List<Raporlar>> RaporlarTip1 = new ResponseMessage<List<Raporlar>>();

        public ResponseMessage<List<Raporlar>> RaporlarTip2 = new ResponseMessage<List<Raporlar>>();

        public ResponseMessage<List<Etkinlikler>> EtkinlikTakvimi = new ResponseMessage<List<Etkinlikler>>();

        public List<Sayfalar> listSayfalar = new List<Sayfalar>();

        public string YaziTipi = "";

        public string mkUyeTipi = "";

        public int UstIdSec = 0;

        public int SayfaIdSec = 0;

        public int Grup = 1;

        public int RaporTipSec = 1;

        public string stringUrl = "";

    }
}