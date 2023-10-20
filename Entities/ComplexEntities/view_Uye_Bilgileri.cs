namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("view_Uye_Bilgileri")]
    public partial class view_Uye_Bilgileri : IEntity
    {
        [Key]
        [Column("OID")]
        public string OID { get; set; }
        public int ID { get; set; }

        public string FIRMA_NO { get; set; }

        public string FIRMA_OID { get; set; }

        public string UYE_ODA_SICIL_NO { get; set; }
        public string VERGI_NO { get; set; }
        //TICARET_SICIL_NO
        public string strID { get; set; }

        public string UYELIK_DURUM { get; set; }

        public DateTime? UYELIK_KARAR_TARIHI { get; set; }

        public DateTime? ODA_TESCIL_TARIHI { get; set; }

        public string UNVAN { get; set; }

        public string FIRMA_TIPI { get; set; }

        public string WEB_ADRESI { get; set; }

        public string MESLEK_GRUBU_NO { get; set; }

        public string MESLEK_GRUBU_ADI { get; set; }

        public string VERGI_DURUMU { get; set; }
        public string VERGI_DAIRESI { get; set; }
        public string BUTUNLESIK_ADRES { get; set; }

        public string UYELIK_OID { get; set; }

        public string UYELIKNACE_OID { get; set; }

        public string MESLEKNACE_OID { get; set; }

        public string UYEADRES_OID { get; set; }

        public string UYEADRESUYELIK_OID { get; set; }

        public string MESLEKGRUBU_OID { get; set; }


    }
}
