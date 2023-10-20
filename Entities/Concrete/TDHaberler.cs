namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("TDHaberler")]
    public partial class TDHaberler : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        public int Tip { get; set; }
        [NotMapped]
        public string Tip_ { get; set; }

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(200)]
        public string DosyaUrl { get; set; }

        [Required]
        [StringLength(200)]
        public string ResimUrl { get; set; }

        [Required]
        [StringLength(200)]
        public string KucukResimUrl { get; set; }

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

        [NotMapped]
        public Byte[] Resim { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
