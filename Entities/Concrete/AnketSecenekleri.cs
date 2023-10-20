namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("AnketSecenekleri")]
    public partial class AnketSecenekleri : IEntity
    {
        public int ID { get; set; }

        public int AnketID { get; set; }

        public int SiraNo { get; set; }

        [Required]
        [StringLength(200)]
        public string Aciklama { get; set; }

        public int OySayisi { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
