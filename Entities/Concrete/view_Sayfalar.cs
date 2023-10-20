namespace WebApplication1.Models
{
    using Core.Entities;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("view_Sayfalar")]
    public partial class view_Sayfalar : IEntity
    {
        public int ID { get; set; }

        public int UstID { get; set; }

        public bool Etkin { get; set; }

        public int SiraNo { get; set; }

        public string SayfaURL { get; set; }

        public string Baslik { get; set; }

        [NotMapped]
        public string strID { get; set; } = "";



    }
}
