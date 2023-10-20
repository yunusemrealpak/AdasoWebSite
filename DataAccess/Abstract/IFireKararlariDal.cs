using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IFireKararlariDal : IEntityRepository<FireKararlari>
    {
        List<FireKararlari> GetListWithPaging(FireKararlariFilter filter);
        int GetListWithPagingCount(FireKararlariFilter filter);
        new int GetMaxId();
    }
}
