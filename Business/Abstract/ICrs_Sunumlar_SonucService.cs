using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface ICrs_Sunumlar_SonucService
    {

        IDataResult<IList<Crs_Sunumlar_Sonuc>> GetList();
        IDataResult<IList<Crs_Sunumlar_Sonuc>> GetListWithFilter(SunumlarFilter filter);
    }
}