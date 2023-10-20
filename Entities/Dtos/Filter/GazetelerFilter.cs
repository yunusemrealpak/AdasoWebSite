using System;

namespace Entities.Dtos.Filter
{

    public class GazetelerFilter : FilterDTO
    {
        public string sayi { get; set; }
        public DateTime tarih { get; set; }

        public string Baslik { get; set; }

    }
}
