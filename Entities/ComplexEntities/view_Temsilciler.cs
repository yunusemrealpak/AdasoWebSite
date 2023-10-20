namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("view_Temsilciler")]
    public partial class view_Temsilciler : IEntity
    {
        public int ID { get; set; }

        public string TEMSILCI_KISI_OID { get; set; }

        public string strID { get; set; }

        public string ADI { get; set; }

        public string SOYADI { get; set; }

        public DateTime? YETKI_BASLANGIC_TARIHI { get; set; }

        public DateTime? YETKI_BITIS_TARIHI { get; set; }



    }
}
