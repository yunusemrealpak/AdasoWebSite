using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface ITDHaberlerDal : IEntityRepository<TDHaberler>
    {
        List<TDHaberler> GetListWithPaging(YazilarFilter filter);

        int GetListWithPagingCount(YazilarFilter filter);
        new int GetMaxId();
    }
}
