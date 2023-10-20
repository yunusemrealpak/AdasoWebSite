namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Etkinlikler")]
    public partial class Etkinlikler : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        [Required]
        [StringLength(200)]
        public string Yer { get; set; }

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Metin { get; set; }

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
        public DateTime? GuncellemeTarihi { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }

        [StringLength(200)]
        public string DosyaURL { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
