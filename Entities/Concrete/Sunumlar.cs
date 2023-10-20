namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Sunumlar")]
    public partial class Sunumlar : IEntity
    {
        public int ID { get; set; }

        public bool Etkin { get; set; }
        public string AnaBaslik { get; set; }
        public string Baslik { get; set; }

        public string Metin { get; set; }

        public string DosyaURL { get; set; }

        public string Ekleyen { get; set; }

        public string Hazirlayan { get; set; }

        public DateTime SunumTarihi { get; set; }
        public DateTime EklemeTarihi { get; set; }

        public string Guncelleyen { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        [NotMapped]
        public string strID { get; set; }
    }
}
