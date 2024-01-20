namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("MKUyeler")]
    public partial class MKUyeler : IEntity
    {
        public int ID { get; set; }

        public int DonemID { get; set; }

        public int UyeID { get; set; }

        public byte[] Resim { get; set; }

        public string KimlikNo { get; set; }

        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string MeslekGrubuKodu { get; set; }

        public string Gorev { get; set; }

        public string Adres { get; set; }

        public string Telefon { get; set; }

        public string Faks { get; set; }

        public string EvAdresi { get; set; }

        public string EvTelefonu { get; set; }

        public string CepTelefonu { get; set; }

        public string EPosta { get; set; }

        public string IstigalKonusu { get; set; }

        public string EgitimDurumu { get; set; }

        public string LiseAdi { get; set; }

        public string UniversiteAdi { get; set; }

        public string FakulteAdi { get; set; }

        public string YabanciDil { get; set; }

        public string EkGorev1 { get; set; }

        public string EkGorev2 { get; set; }

        public string EkGorev3 { get; set; }

        public bool Etkin { get; set; }

        public bool HesapIncelemeKomisyonuUyesi { get; set; }

        public bool MevzuatKomisyonuUyesi { get; set; }

        public bool TOBBGenelKurulDelegesi { get; set; }

        public bool MeslekKomitesiAsilUyesimi { get; set; }

        public int MeslekKomitesiUyelikDurum { get; set; }

        public int MeslekKomitesiUyesiGorevTipi { get; set; }

        public DateTime MeslekKomitesiUyelikBaslamaTarihi { get; set; }

        public bool MeslekKomitesiUyelikDustu { get; set; }

        public DateTime MeslekKomitesiUyelikDususTarihi { get; set; }

        public bool MeclisAsilUyesimi { get; set; }

        public int MeclisUyelikDurum { get; set; }

        public int MeclisUyesiGorevTipi { get; set; }

        public DateTime MeclisUyelikBaslamaTarihi { get; set; }

        public bool MeclisUyelikDustu { get; set; }

        public DateTime MeclisUyelikDususTarihi { get; set; }

        public bool YonetimKuruluAsilUyesimi { get; set; }

        public int YonetimKuruluUyelikDurum { get; set; }

        public int YonetimKuruluUyesiGorevTipi { get; set; }

        public DateTime YonetimKuruluUyelikBaslamaTarihi { get; set; }

        public bool YonetimKuruluUyelikDustu { get; set; }

        public DateTime YonetimKuruluUyelikDususTarihi { get; set; }

        public int YonetimKuruluSiraNo { get; set; }

        public string Aciklama { get; set; }

        public int YonetimKuruluSira { get; set; }

        public int MeclisSira { get; set; }

        public int MeslekKomistesiSira { get; set; }
        [NotMapped]
        public string strID { get; set; }

        public string unvan { get; set; }

    }
}
