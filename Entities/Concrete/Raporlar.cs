namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Raporlar")]
    public partial class Raporlar : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        public int Tip { get; set; }

        public string Baslik { get; set; }

        public string AltBaslik { get; set; }

        public string DosyaUrl { get; set; }

        public string ResimUrl { get; set; }

        public string KucukResimUrl { get; set; }

        public int GosterimSayisi { get; set; }

        public string Ekleyen { get; set; }

        public DateTime EklemeTarihi { get; set; }

        public string Guncelleyen { get; set; }

        public DateTime? GuncellemeTarihi { get; set; }

        public bool? Sil { get; set; }

        public DateTime? OlusturmaTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
