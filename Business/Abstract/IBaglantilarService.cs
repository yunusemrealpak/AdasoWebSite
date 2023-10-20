using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IBaglantilarService
    {
        IResult Add(Baglantilar Baglantilar);

        IResult Delete(Baglantilar Baglantilar);

        IDataResult<Baglantilar> GetById(int Id);

        IDataResult<IList<Baglantilar>> GetList();

        IResult Update(Baglantilar Baglantilar);
        IDataResult<IList<Baglantilar>> GetListWithPaging(BaglantilarFilter filter);
        int GetListWithPagingCount(BaglantilarFilter filter);
        IDataResult<int> GetMaxId();
    }
}

