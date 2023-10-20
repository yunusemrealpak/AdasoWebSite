using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IRaporlarService
    {
        IResult Add(Raporlar Raporlar);

        IResult Delete(Raporlar Raporlar);

        IDataResult<Raporlar> GetById(int Id);

        IDataResult<IList<Raporlar>> GetList();

        IDataResult<IList<Raporlar>> GetRaporTipList(RaporFilter filter);

        IDataResult<IList<Raporlar>> GetListWithPaging(RaporFilter filter);

        int GetListWithPagingCount(RaporFilter filter);

        IDataResult<int> GetMaxId();

        IResult Update(Raporlar Raporlar);

    }
}

