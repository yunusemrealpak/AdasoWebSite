using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface Iview_Uye_BilgileriDal : IEntityRepository<view_Uye_Bilgileri>
    {

        List<view_Uye_Bilgileri> GetListWithPaging(firmalarFilter filter);
        int GetListWithPagingCount(firmalarFilter filter);
        new int GetMaxId();
    }
}
