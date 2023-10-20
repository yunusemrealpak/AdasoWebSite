using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IMKUyelerService
    {
        IDataResult<IList<MKUyeler>> GetListWithPaging(MkUyelerFilter filter);

        int GetListWithPagingCount(MkUyelerFilter filter);

        IDataResult<int> GetMaxId();

        IDataResult<MKUyeler> GetById(int Id);

        IDataResult<IList<MKUyeler>> GetList();


    }
}

