namespace Entities.Dtos.Filter
{
    public class MkUyelerFilter : FilterDTO
    {
        public string ara_ { get; set; }
        public int DonemID { get; set; }
        public string MeslekGrubuKodu { get; set; }
        public bool Etkin { get; set; }
        public bool MeclisAsilUyesimi { get; set; }
        public int MeclisUyelikDurum { get; set; }

        public bool YonetimKuruluAsilUyesimi { get; set; }

        public int YonetimKuruluUyelikDurum { get; set; }
        public bool MeslekKomitesiAsilUyesimi { get; set; }

        public int MeslekKomitesiUyelikDurum { get; set; }

    }
}
