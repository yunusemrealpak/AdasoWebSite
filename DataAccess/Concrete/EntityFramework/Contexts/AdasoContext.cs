using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class AdasoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source = 172.168.110.15; initial catalog = dbADASOWeb; persist security info = True; user id = sa; password = 1;  TrustServerCertificate=True;Encrypt=True");
            //optionsBuilder.UseSqlServer("Persist Security Info=False;User ID=sa;Initial Catalog=dbADASOWeb;Data Source=172.168.110.15; Password=1;TrustServerCertificate=True;Encrypt=True");
            //optionsBuilder.UseSqlServer(@"data source = ISMAILGUNDOGAN; initial catalog = dbADASOWeb; persist security info = True; user id = sa; password = saw; MultipleActiveResultSets = True;");
            //optionsBuilder.UseSqlServer(@"data source = 172.20.1.51; initial catalog = dbADASOWeb; persist security info = True; user id = sa; password = 2656_Tahir; MultipleActiveResultSets = True;");
            //optionsBuilder.UseSqlServer(@"data source = 176.235.236.6; initial catalog = MesajKuyrukDB; persist security info = True; user id = sa; password = 2656_Tahir; MultipleActiveResultSets = True;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public virtual DbSet<AlbumGorselleri> AlbumGorselleri { get; set; }
        public virtual DbSet<Albumler> Albumler { get; set; }
        public virtual DbSet<Anketler> Anketler { get; set; }
        public virtual DbSet<AnketSecenekleri> AnketSecenekleri { get; set; }
        public virtual DbSet<Baglantilar> Baglantilar { get; set; }
        public virtual DbSet<DosyaYonetimi> DosyaYonetimi { get; set; }
        public virtual DbSet<EIP> EIP { get; set; }
        public virtual DbSet<Etkinlikler> Etkinlikler { get; set; }
        public virtual DbSet<FireKararlari> FireKararlari { get; set; }
        public virtual DbSet<Gazeteler> Gazeteler { get; set; }
        public virtual DbSet<IslemGecmisHareketleri> IslemGecmisHareketleri { get; set; }
        public virtual DbSet<Kullanicilar> Kullanicilar { get; set; }
        public virtual DbSet<MKUyeler> MKUyeler { get; set; }
        public virtual DbSet<Projeler> Projeler { get; set; }
        public virtual DbSet<Raporlar> Raporlar { get; set; }
        public virtual DbSet<Sayfalar> Sayfalar { get; set; }
        public virtual DbSet<view_Sayfalar> view_Sayfalar { get; set; }
        public virtual DbSet<TDHaberler> TDHaberler { get; set; }
        public virtual DbSet<Tebligler> Tebligler { get; set; }
        public virtual DbSet<TebliglerUI> TebliglerUI { get; set; }
        public virtual DbSet<Yazilar> Yazilar { get; set; }
        public virtual DbSet<SliderUI> Sliders { get; set; }
        public virtual DbSet<DuyurularUI> DuyurularUI { get; set; }
        public virtual DbSet<Youtube> Youtube { get; set; }
        public virtual DbSet<Sunumlar> Sunumlar { get; set; }        
        public virtual DbSet<Crs_Sunumlar_Sonuc> Crs_Sunumlar_Sonuc { get; set; }
        public virtual DbSet<MesajKuyruklar> MesajKuyruklar { get; set; }

        //public virtual DbSet<View_Base_OFirmaAdres> View_Base_OFirmaAdres { get; set; }

        //public virtual DbSet<View_Base_OFirmaIletisim> View_Base_OFirmaIletisim { get; set; }
        public virtual DbSet<View_Base_OFirmalar> View_Base_OFirmalar { get; set; }
        public virtual DbSet<view_Uye_Bilgileri> view_Uye_Bilgileri { get; set; }
        public virtual DbSet<view_Temsilciler> view_Temsilciler { get; set; }
        public virtual DbSet<view_MeslekGruplari> view_MeslekGruplari { get; set; }
        public virtual DbSet<view_ortaklik> view_ortaklik { get; set; }
        public virtual DbSet<View_Base_Hedef_Tekrar_Getir> View_Base_Hedef_Tekrar_Getir { get; set; }
        public DbSet<proc_Adaso_org_tr_GenelArama> proc_Adaso_org_tr_GenelArama { get; set; }
        public DbSet<view_UyeUyelikSabitTelefon> view_UyeUyelikSabitTelefon { get; set; }
        public virtual DbSet<MobilVersiyonKontrol> MobilVersiyonKontrol { get; set; }
    }
}