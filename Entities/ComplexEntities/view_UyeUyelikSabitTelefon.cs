namespace WebApplication1.Models
{
    using Core.Entities;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("view_UyeUyelikSabitTelefon")]
    public class view_UyeUyelikSabitTelefon : IEntity
    {
        public string OID { get; set; }

        //UYELIK_OID
        public string strID { get; set; }

        public decimal TELEFON_TIPI { get; set; }

        public string ULKE_TEL_KODU { get; set; }

        public string TELEFON_NO { get; set; }

        public string ACIKLAMA { get; set; }

        public string BIRINCIL_TELEFON { get; set; }

        public string CREATED { get; set; }

        public string CREATED_BY { get; set; }
        public int ID { get; set; }

    }
}
