namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("view_MeslekGruplari")]
    public partial class view_MeslekGruplari : IEntity
    {
        [Key]
        [Column("OID")]
        public string OID { get; set; }
        public int ID { get; set; }
        public string ODA_BORSA_NO { get; set; }

        public string ODA_BORSA_SUBE_NO { get; set; }

        public string MESLEK_GRUBU_NO { get; set; }

        public string MESLEK_GRUBU_ADI { get; set; }

        public string BASLANGIC_TARIHI { get; set; }

        public string BITIS_TARIHI { get; set; }

        public string KAYIT_KARAR_NO { get; set; }

        public string KAYIT_KARAR_TARIHI { get; set; }

        public string TOBB_KAYIT_KARAR_NO { get; set; }

        public string TOBB_KAYIT_KARAR_TARIHI { get; set; }

        public string DURUM { get; set; }

        public DateTime? CREATED { get; set; }

        public string CREATED_BY { get; set; }

        public string MESLEK_GRUBU_SIRANO { get; set; }
        public string TICARET_SICIL_NO { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
