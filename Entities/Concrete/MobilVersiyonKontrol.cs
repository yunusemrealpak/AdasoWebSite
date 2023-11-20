namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;



    [Table("MobilVersiyonKontrol")]
    public partial class MobilVersiyonKontrol : IEntity
    {
        public int ID { get; set; }

        public int os { get; set; }
        public string version { get; set; }
 
        public string url { get; set; }

        public int action { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
