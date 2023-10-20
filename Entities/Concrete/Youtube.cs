namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("Youtube")]
    public partial class Youtube : IEntity
    {
        public int ID { get; set; }
        public System.Guid GUID { get; set; }
        public bool Etkin { get; set; }
        public System.DateTime Tarih { get; set; }
        public int GosterimSayisi { get; set; }

        [Required]
        [StringLength(200)]
        public string Baslik { get; set; }
        public string VideoURL { get; set; }
        public string ResimURL { get; set; }
        public Nullable<bool> Sil { get; set; }
        public Nullable<System.DateTime> OlusturmaTarihi { get; set; }

        public int Sira { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
