namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("DuyurularUI")]
    public partial class DuyurularUI : IEntity
    {
        public int ID { get; set; }

        public string Baslik { get; set; }

        public bool Etkin { get; set; }

        public DateTime BitisTarihi { get; set; }

        public DateTime BaslangicTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
