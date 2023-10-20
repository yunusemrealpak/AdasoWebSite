namespace WebApplication1.Models
{
    using Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Kullanicilar")]
    public partial class Kullanicilar : IEntity
    {
        public int ID { get; set; }

        //public Guid GUID { get; set; }

        //public bool Etkin { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string Rol { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string Ad { get; set; }

        [Required]
        [StringLength(50)]
        public string Soyad { get; set; }

        //[Required]
        //[StringLength(50)]
        //public string EPosta { get; set; }

        //[Required]
        //[StringLength(100)]
        //public string Parola { get; set; }

        //[Column(TypeName = "smalldatetime")]
        //public DateTime OlusturmaTarihi { get; set; }

        //[Column(TypeName = "smalldatetime")]
        //public DateTime SonGirisTarihi { get; set; }

        //public bool? Sil { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
