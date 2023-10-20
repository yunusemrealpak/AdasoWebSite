using System;

namespace Entities.Dtos.Filter
{
    public class TebliglerFilter : FilterDTO
    {
        public string Baslik { get; set; }
        public DateTime Tarih { get; set; }
    }
}
