namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("View_Base_Hedef_Tekrar_Getir")]
    public partial class View_Base_Hedef_Tekrar_Getir : IEntity
    {
        //public int hedefTekrarID { get; set; }

        public int? HedefID { get; set; }

        public string hedefTekrarBaslik { get; set; }

        public string hedefTekrarAciklama { get; set; }

        public int? hedefTekrarSira { get; set; }

        public bool? hedefTekrarSistem { get; set; }

        public DateTime? hedefTekrarOlTarih { get; set; }

        public bool? hedefTekrarFaaliyetMi { get; set; }

        public string hedefTekrarFaaliyetTur { get; set; }

        public DateTime hedefTekrarFaaliyetBasTarih { get; set; }

        public DateTime hedefTekrarFaaliyetBitTarih { get; set; }

        public string hedefTekrarFaaliyetKodu { get; set; }

        public string hedefTekrarFaaliyetXKoordinat { get; set; }

        public string hedefTekrarFaaliyetYKoordinat { get; set; }

        public bool? hedefTekrarFaaliyetKilitle { get; set; }

        public string hedefTekrarFaaliyetAciklama { get; set; }

        public string hedefTekrarFaaliyetYer { get; set; }

        public int? UyeAnketID { get; set; }

        public string hedefTekrarFaaliyetAciklama1 { get; set; }

        public string HedefTekrarFaaliyetBilgilendirmeTip { get; set; }

        public bool? hedefTekrarMobilGoster { get; set; }

        public string hedefTekrarFaaliyetDurumRenk { get; set; }


        public int ID { get; set; }

        [NotMapped]
        public string strID { get; set; }
    }
}
