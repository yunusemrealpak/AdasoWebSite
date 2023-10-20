using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface Iproc_Adaso_org_tr_GenelAramaDal : IEntityRepository<proc_Adaso_org_tr_GenelArama>
    {
        List<proc_Adaso_org_tr_GenelArama> GetListWithPaging(SearchFilter filter);
        int GetListWithPagingCount(SearchFilter filter);

    }
}
