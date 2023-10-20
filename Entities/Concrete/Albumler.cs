namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Albumler")]
    public partial class Albumler : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(200)]
        public string Ad { get; set; }

        [Required]
        [StringLength(200)]
        public string KucukResimURL { get; set; }

        public int ResimSayisi { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
