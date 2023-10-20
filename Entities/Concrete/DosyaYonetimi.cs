namespace WebApplication1.Models
{
    using Core.Entities;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DosyaYonetimi")]
    public partial class DosyaYonetimi : IEntity
    {
        public int ID { get; set; }
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public decimal FileSize { get; set; }

        public string FileSizeStr { get; set; }

        public DateTime? CreateDate { get; set; }

        public string FileExtension { get; set; }

        public bool? Status { get; set; }

        [NotMapped]
        public string strID { get; set; }
    }
}
