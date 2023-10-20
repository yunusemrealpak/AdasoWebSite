namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("SliderUI")]
    public partial class SliderUI : IEntity
    {
        public int ID { get; set; }

        public int Grup { get; set; }

        public int Tip { get; set; }

        public bool Etkin { get; set; }

        public DateTime BaslangicTarihi { get; set; }

        public DateTime BitisTarihi { get; set; }

        public string Baslik { get; set; }

        public string ResimUrl { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
