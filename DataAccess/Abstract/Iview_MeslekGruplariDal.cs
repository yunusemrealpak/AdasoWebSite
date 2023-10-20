using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface Iview_MeslekGruplariDal : IEntityRepository<view_MeslekGruplari>
    {

        List<view_MeslekGruplari> GetListWithPaging(firmalarFilter filter);
        int GetListWithPagingCount(firmalarFilter filter);
        new int GetMaxId();
    }
}
