namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Sayfalar")]
    public partial class Sayfalar : IEntity
    {
        public int ID { get; set; }
        [NotMapped]
        public int detailID { get; set; }
        public Guid GUID { get; set; }

        [Required]
        [StringLength(2)]
        public string Dil { get; set; }

        public int UstID { get; set; }

        public bool Etkin { get; set; }

        [NotMapped]
        public string etkin_ { get; set; }

        public int Duzey { get; set; }

        public int SiraNo { get; set; }

        [Required]
        [StringLength(100)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(100)]
        public string SayfaURL { get; set; }

        [Required]
        [StringLength(50)]
        public string Icerik1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Icerik2 { get; set; }

        [Required]
        [StringLength(50)]
        public string Icerik3 { get; set; }

        public int GosterimSayisi { get; set; }

        [Required]
        [StringLength(50)]
        public string Ekleyen { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime EklemeTarihi { get; set; }

        [Required]
        [StringLength(50)]
        public string Guncelleyen { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime GuncellemeTarihi { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Metin { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }


        [StringLength(200)]
        public string DosyaUrl { get; set; }
        [NotMapped]
        public string strID { get; set; }


        [NotMapped]
        public List<Sayfalar> subMenus { get; set; } = new List<Sayfalar>();


    }
}
