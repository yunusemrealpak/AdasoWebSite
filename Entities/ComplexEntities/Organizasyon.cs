namespace WebApplication1.Models
{
    using Core.Entities;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Organizasyon")]
    public partial class Organizasyon : IEntity
    {
        [NotMapped]
        public int ID { get; set; }
        [NotMapped]
        public string strID { get; set; }

        public int id { get; set; }
        public int ýyeID { get; set; }
        public string resim { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string unvan { get; set; }
        public string gorev { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }
        public string faks { get; set; }
        public string ePosta { get; set; }
        public int YSira { get; set; }
        public int MSira { get; set; }
        public int MKSira { get; set; }
        public string MeslekGrubuKodu { get; set; }
        public string MeslekGrubuAdi { get; set; }




    }
}
