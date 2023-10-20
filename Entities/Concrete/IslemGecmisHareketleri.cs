namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("IslemGecmisHareketleri")]
    public partial class IslemGecmisHareketleri : IEntity
    {
        public int ID { get; set; }

        public Guid GUID { get; set; }

        [Required]
        [StringLength(250)]
        public string Aciklama { get; set; }

        [Required]
        [StringLength(50)]
        public string Konum { get; set; }

        [Required]
        [StringLength(50)]
        public string IslemiYapan { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime IslemTarihi { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }
        public int tableID { get; set; }

        [NotMapped]
        public string strID { get; set; }



    }
}
