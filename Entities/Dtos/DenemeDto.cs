using System.Collections.Generic;
using WebApplication1.Models;

namespace Entities.Dtos
{
    public class DenemeDto
    {
        public TDHaberler Haber { get; set; }
        public List<TDHaberler> Haberler { get; set; }
    }
}
