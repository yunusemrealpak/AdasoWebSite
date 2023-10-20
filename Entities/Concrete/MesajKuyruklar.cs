namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("MesajKuyruklar")]
    public partial class MesajKuyruklar : IEntity
    {

        public string UygulamaAdi { get; set; }

        public string mesajKuyrukTip { get; set; }

        public string mesajKuyrukAltTip { get; set; }

        public string PersonelAdi { get; set; }

        public string PersonelSoyadi { get; set; }

        public string PersonelEmail { get; set; }

        public string mesajKuyrukBaslik { get; set; }

        public string mesajKuyrukIcerik { get; set; }

        public string mesajKuyrukDosya1Src { get; set; }

        public string mesajKuyrukDosya2Src { get; set; }

        public string mesajKuyrukDosya3Src { get; set; }

        [NotMapped]
        public string baslik { get; set; }

        public DateTime? mesajKuyrukDosyaOlTarih { get; set; }

        public DateTime? mesajKuyrukDosyaGonTarih { get; set; }

        public bool? mesajKuyrukGonderildiMi { get; set; }

        [Column("mesajKuyrukID")]
        public int ID { get; set; }

        [NotMapped]
        public string strID { get; set; }
    }
}
