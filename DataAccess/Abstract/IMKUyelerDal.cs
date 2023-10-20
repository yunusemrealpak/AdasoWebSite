using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IMKUyelerDal : IEntityRepository<MKUyeler>
    {
        List<MKUyeler> GetListWithPaging(MkUyelerFilter filter);
        int GetListWithPagingCount(MkUyelerFilter filter);
        new int GetMaxId();
    }
}
