using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface Iproc_Adaso_org_tr_GenelAramaService
    {
        IDataResult<IList<proc_Adaso_org_tr_GenelArama>> GetListWithPaging(SearchFilter filter);

        int GetListWithPagingCount(SearchFilter filter);



    }
}

