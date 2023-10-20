using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface ISunumlarService
    {
        IDataResult<IList<Sunumlar>> GetListWithPaging(SunumlarFilter filter);
        int GetListWithPagingCount(SunumlarFilter filter);
        IDataResult<int> GetMaxId();
        IDataResult<Sunumlar> GetById(int Id);
        IDataResult<IList<Sunumlar>> GetList();
        IResult Add(Sunumlar Sunumlar);
        IResult Delete(Sunumlar Sunumlar);
        IResult Update(Sunumlar Sunumlar);

    }
}