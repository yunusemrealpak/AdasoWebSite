using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IYoutubeDal : IEntityRepository<Youtube>
    {
        List<Youtube> GetListWithPaging(YoutubeFilter filter);
        int GetListWithPagingCount(YoutubeFilter filter);
        new int GetMaxId();
    }
}
