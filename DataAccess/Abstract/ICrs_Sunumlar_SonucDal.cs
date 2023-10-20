using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface ICrs_Sunumlar_SonucDal : IEntityRepository<Crs_Sunumlar_Sonuc>
    {
        List<Crs_Sunumlar_Sonuc> GetListWithFilter(SunumlarFilter filter);
    }

}
