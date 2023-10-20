using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface ISunumlarDal : IEntityRepository<Sunumlar>
    {
        List<Sunumlar> GetListWithPaging(SunumlarFilter filter);
        int GetListWithPagingCount(SunumlarFilter filter);
        new int GetMaxId();
    }
}
