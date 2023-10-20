namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("EIP")]
    public partial class EIP : IEntity
    {
        public int ID { get; set; }

        public DateTime? Tarih { get; set; }

        [StringLength(250)]
        public string FirmaAdi { get; set; }

        [StringLength(250)]
        public string Adres { get; set; }

        [StringLength(250)]
        public string IlgiliKisi { get; set; }

        [StringLength(250)]
        public string Telefon { get; set; }

        [StringLength(250)]
        public string EPosta { get; set; }

        [StringLength(250)]
        public string FaaliyetAlani { get; set; }

        [StringLength(250)]
        public string Konum { get; set; }

        [StringLength(250)]
        public string KisaBilgi { get; set; }

        [StringLength(250)]
        public string Soru2 { get; set; }

        [StringLength(250)]
        public string Soru3 { get; set; }

        [StringLength(250)]
        public string Soru4 { get; set; }

        [StringLength(250)]
        public string Soru5 { get; set; }

        [StringLength(250)]
        public string Soru6 { get; set; }

        [StringLength(250)]
        public string Soru7 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru8 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru9 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru10 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru11 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru12 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru13 { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru14Elektrik { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru14DogalGaz { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru14Komur { get; set; }

        [Column(TypeName = "money")]
        public decimal? Soru14FuelOil { get; set; }

        [StringLength(250)]
        public string Soru15 { get; set; }

        [StringLength(250)]
        public string Soru16 { get; set; }

        [StringLength(1000)]
        public string Soru17 { get; set; }

        public bool? Sil { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? OlusturmaTarihi { get; set; }

        [NotMapped]
        public string strID { get; set; }


    }
}
