using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IView_Base_OFirmalarService
    {

        IDataResult<View_Base_OFirmalar> GetByIdStr(string Id);
        IDataResult<IList<View_Base_OFirmalar>> GetList();
        IDataResult<IList<View_Base_OFirmalar>> GetListWithPaging(firmalarFilter filter);
        int GetListWithPagingCount(firmalarFilter filter);
        IDataResult<int> GetMaxId();



    }
}

