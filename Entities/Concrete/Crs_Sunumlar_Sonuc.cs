namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Crs_Sunumlar_Sonuc")]
    public partial class Crs_Sunumlar_Sonuc : IEntity
    {
        public int ID { get; set; }

        public int Sira { get; set; }

        public string AnaBaslik { get; set; }

        public string baslik { get; set; }

        public string DosyaURL { get; set; }

        public string Hazirlayan { get; set; }

        public DateTime SunumTarihi { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
