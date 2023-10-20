namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("View_Base_OFirmalar")]
    public partial class View_Base_OFirmalar : IEntity
    {
        [Key]
        [Column("OID")]
        public string OID { get; set; }
        public int ID { get; set; }
        public string FIRMA_NO { get; set; }
        public string ODA_BORSA_NO { get; set; }
        public string ODA_BORSA_SUBE_NO { get; set; }
        public string FIRMA_OID { get; set; }
        public string UYE_ODA_SICIL_NO { get; set; }
        public string ODA_TESCIL_TARIHI { get; set; }
        public string BORSA_TESCIL_TARIHI { get; set; }
        public string UYELIK_BIT_TARIHI { get; set; }
        public string UYELIK_KARAR_NO { get; set; }
        public string UYELIK_KARAR_TARIHI { get; set; }
        public Nullable<decimal> UYELIK_TIPI { get; set; }
        public string ESKI_ODA_NO { get; set; }
        public string ESKI_UYE_ODA_SICIL_NO { get; set; }
        public string UYELIK_KAPATMA_KARAR_TARIHI { get; set; }
        public string UYELIK_KAPATMA_KARAR_NO { get; set; }
        public string UNVAN { get; set; }
        public string TABELA_UNVANI { get; set; }
        public string FIRMA_TIPI { get; set; }
        public string ALT_FIRMA_TIPI { get; set; }
        public string VERGI_NO { get; set; }
        public string TC_KIMLIK_NO { get; set; }

        [StringLength(14)]
        public string TICARET_SICIL_NO { get; set; }
        public string TSM_KODU { get; set; }
        public string FIRMA_KURULUS_TARIHI { get; set; }
        public string FIRMA_KAPANIS_TARIHI { get; set; }
        public Nullable<decimal> FIRMA_UYRUK { get; set; }
        public string VERGI_DAIRESI_KODU { get; set; }
        public string VERGI_DURUMU { get; set; }
        public string VERGI_TERK_TARIHI { get; set; }
        public string MERSIS_NO { get; set; }
        public string SM_KODU { get; set; }
        public string SMMM_ADI_SOYADI { get; set; }
        public Nullable<decimal> TERKIN_NUMARASI { get; set; }
        public string ACIKLAMA { get; set; }
        public string UYE_TIPI { get; set; }
        public string SGK_NO { get; set; }
        public string UYELIK_DURUM { get; set; }
        public string YERINDE_ZIYARET { get; set; }
        public string YONETIM_ORGANI { get; set; }
        public string ESNAF_SICIL_NO { get; set; }
        public string BILANCO_MERKEZ_MI { get; set; }
        public Nullable<System.DateTime> CREATED { get; set; }
        public string CREATED_BY { get; set; }
        public string ODA_BOLGE_KODU { get; set; }
        public Nullable<decimal> KURUMNO { get; set; }
        public string KISI_OID { get; set; }
        public string BASKA_ODADA_UYELIGI_VAR { get; set; }
        public string YABANCI_UYRUKLU_KISI { get; set; }
        public Nullable<System.DateTime> CREATE_DATE { get; set; }
        [NotMapped]
        public string strID { get; set; }




    }
}
