namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Baglantilar")]
    public partial class Baglantilar : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        public int GrupKodu { get; set; }

        [Required]
        [StringLength(100)]
        public string Grup { get; set; }

        public int SiraNo { get; set; }

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(200)]
        public string WebAdresi { get; set; }

        public bool YeniPencere { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
