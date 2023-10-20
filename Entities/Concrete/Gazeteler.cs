namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Gazeteler")]
    public partial class Gazeteler : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        public bool Etkin { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }

        public int Sayi { get; set; }

        [Required]
        [StringLength(200)]
        public string DosyaURL { get; set; }

        [Required]
        [StringLength(200)]
        public string ResimURL { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
