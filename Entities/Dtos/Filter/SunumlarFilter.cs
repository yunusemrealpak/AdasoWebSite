namespace Entities.Dtos.Filter
{
    public class SunumlarFilter : FilterDTO
    {
        public string Baslik { get; set; }
        public string anaBaslik { get; set; }
        public int sunumYear { get; set; }
        public int sunumMounth { get; set; }
        public string txtContainsSearch { get; set; }

    }
}
