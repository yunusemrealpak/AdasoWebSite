using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IYoutubeService
    {
        IDataResult<IList<Youtube>> GetListWithPaging(YoutubeFilter filter);
        int GetListWithPagingCount(YoutubeFilter filter);
        IDataResult<int> GetMaxId();
        IDataResult<Youtube> GetById(int Id);
        IDataResult<IList<Youtube>> GetList();
        IResult Add(Youtube Youtube);
        IResult Delete(Youtube Youtube);
        IResult Update(Youtube Youtube);

    }
}