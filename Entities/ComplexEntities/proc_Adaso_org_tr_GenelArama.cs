namespace WebApplication1.Models
{
    using Core.Entities;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("proc_Adaso_org_tr_GenelArama")]
    public partial class proc_Adaso_org_tr_GenelArama : IEntity
    {
        [Key]
        public int ID { get; set; }
        public int tID { get; set; }
        [NotMapped]
        public int skip { get; set; }
        [NotMapped]
        public int take { get; set; }
        [NotMapped]
        public int page { get; set; }

        [NotMapped]
        public string serachKey { get; set; }

        [NotMapped]
        public string strID { get; set; }
        public int Count { get; set; }
        public string Baslik { get; set; }
        public string Metin { get; set; }
        public string Sayfa { get; set; }
        public string Kategori { get; set; }
        public string link { get; set; }

    }
}
