using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IRaporlarDal : IEntityRepository<Raporlar>
    {
        List<Raporlar> GetList();
        List<Raporlar> GetRaporTipList(RaporFilter filter);
        int GetListWithPagingCount(RaporFilter filter);
        List<Raporlar> GetListWithPaging(RaporFilter filter);
        new int GetMaxId();
    }
}
