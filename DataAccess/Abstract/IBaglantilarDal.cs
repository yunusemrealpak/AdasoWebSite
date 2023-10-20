using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IBaglantilarDal : IEntityRepository<Baglantilar>
    {
        List<Baglantilar> GetListWithPaging(BaglantilarFilter filter);
        int GetListWithPagingCount(BaglantilarFilter filter);
        new int GetMaxId();
    }
}
