namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("FireKararlari")]
    public partial class FireKararlari : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(2)]
        public string MeslekGrubuKodu { get; set; }

        [Required]
        [StringLength(500)]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(100)]
        public string DosyaURL { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
