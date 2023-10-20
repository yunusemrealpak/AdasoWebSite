using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IGazetelerDal : IEntityRepository<Gazeteler>
    {
        List<Gazeteler> GetListHomePageMagazine();
        List<Gazeteler> GetListWithPaging(GazetelerFilter filter);
        int GetListWithPagingCount(GazetelerFilter filter);
        new int GetMaxId();
    }
}
