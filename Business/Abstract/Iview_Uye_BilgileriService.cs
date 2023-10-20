using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface Iview_Uye_BilgileriService
    {

        IDataResult<view_Uye_Bilgileri> GetByIdStr(string Id);
        IDataResult<IList<view_Uye_Bilgileri>> GetList();
        IDataResult<IList<view_Uye_Bilgileri>> GetListWithPaging(firmalarFilter filter);
        int GetListWithPagingCount(firmalarFilter filter);
        IDataResult<int> GetMaxId();



    }
}

