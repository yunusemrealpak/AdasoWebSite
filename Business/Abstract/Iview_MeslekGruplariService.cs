using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface Iview_MeslekGruplariService
    {

        IDataResult<view_MeslekGruplari> GetByIdStr(string Id);
        IDataResult<IList<view_MeslekGruplari>> GetList();
        IDataResult<IList<view_MeslekGruplari>> GetListWithPaging(firmalarFilter filter);
        int GetListWithPagingCount(firmalarFilter filter);
        IDataResult<int> GetMaxId();



    }
}

