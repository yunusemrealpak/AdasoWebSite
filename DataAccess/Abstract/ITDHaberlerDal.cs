using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface ITDHaberlerDal : IEntityRepository<TDHaberler>
    {
        List<TDHaberler> GetListWithPaging(YazilarFilter filter);

        List<TDHaberler> GetListWithTakeCount(int takeCount);

        int GetListWithPagingCount(YazilarFilter filter);
        new int GetMaxId();
    }
}
