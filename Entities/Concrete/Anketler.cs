namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Anketler")]
    public partial class Anketler : IEntity
    {
        public int ID { get; set; }

        public bool Etkin { get; set; }

        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(200)]
        public string Soru { get; set; }

        public int OySayisi { get; set; }

        [Required]
        [StringLength(50)]
        public string Ekleyen { get; set; }

        public DateTime EklemeTarihi { get; set; }

        [Required]
        [StringLength(50)]
        public string Guncelleyen { get; set; }

        public DateTime GuncellemeTarihi { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }



    }
}
