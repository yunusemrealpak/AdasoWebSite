namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("view_ortaklik")]
    public partial class view_ortaklik : IEntity
    {
        [Key]
        [Column("OID")]
        public string OID { get; set; }
        public int ID { get; set; }

        //UYELIK_OID
        public string strID { get; set; }

        public string ADI { get; set; }

        public string SOYADI { get; set; }

        public decimal? TAAHHUT_EDILEN_SERMAYE { get; set; }

        public DateTime? ORTAKLIK_BASLANGIC_TARIHI { get; set; }

        public DateTime? ORTAKLIK_BITIS_TARIHI { get; set; }



    }
}
