namespace Entities.Dtos.Filter
{

    public class RaporFilter : FilterDTO
    {
        public string Baslik { get; set; }
        public bool Etkin { get; set; } = true;
        public int Tip { get; set; }
    }
}
