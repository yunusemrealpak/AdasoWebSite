using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IView_Base_OFirmalarDal : IEntityRepository<View_Base_OFirmalar>
    {

        List<View_Base_OFirmalar> GetListWithPaging(firmalarFilter filter);
        int GetListWithPagingCount(firmalarFilter filter);
        new int GetMaxId();
    }
}
