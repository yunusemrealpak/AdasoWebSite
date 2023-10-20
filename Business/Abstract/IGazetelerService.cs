using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IGazetelerService
    {
        IResult Add(Gazeteler Gazeteler);

        IResult Delete(Gazeteler Gazeteler);

        IDataResult<Gazeteler> GetById(int Id);

        IDataResult<IList<Gazeteler>> GetList();

        IDataResult<IList<Gazeteler>> GetListHomePageMagazine();

        IDataResult<IList<Gazeteler>> GetListWithPaging(GazetelerFilter filter);

        int GetListWithPagingCount(GazetelerFilter filter);

        IDataResult<int> GetMaxId();
        IResult Update(Gazeteler Gazeteler);

    }
}

