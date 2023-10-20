namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("AlbumGorselleri")]
    public partial class AlbumGorselleri : IEntity
    {
        public int ID { get; set; }

        public Guid AlbumGUID { get; set; }

        [Required]
        [StringLength(200)]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(200)]
        public string ResimURL { get; set; }

        [Required]
        [StringLength(200)]
        public string KucukResimURL { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }

        public int Sira { get; set; }

    }
}
