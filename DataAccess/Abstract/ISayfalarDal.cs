using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface ISayfalarDal : IEntityRepository<Sayfalar>
    {
        int GetListWithPagingCount(SayfalarFilter filter);
        List<Sayfalar> GetListWithPaging(SayfalarFilter filter);

        List<view_Sayfalar> GetListPageTitle();
        new int GetMaxId();
    }
}
