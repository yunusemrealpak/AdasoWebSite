namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("TebliglerUI")]
    public partial class TebliglerUI : IEntity
    {
        public int ID { get; set; }

        public string Baslik { get; set; }

        public DateTime Tarih { get; set; }

        public DateTime EklemeTarihi { get; set; }
        [NotMapped]
        public string strID { get; set; }


    }
}
