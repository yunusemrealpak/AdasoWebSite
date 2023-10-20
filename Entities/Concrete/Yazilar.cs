namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Yazilar")]
    public partial class Yazilar : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public Guid AlbumGUID { get; set; }

        public int Grup { get; set; }

        public int Tip { get; set; }


        public string KategoriAdi { get; set; }

        public bool Etkin { get; set; }

        [NotMapped]
        public string etkin_ { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(500)]
        public string AltBaslik { get; set; }

        //[Required]
        [StringLength(200)]
        public string ResimUrl { get; set; }

        //[Required]
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
        public DateTime GuncellemeTarihi { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Metin { get; set; }

        public bool? Sil { get; set; }
        public bool? Popup { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
