using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface ITebliglerDal : IEntityRepository<Tebligler>
    {
        List<Tebligler> GetListWithPaging(TebliglerFilter filter);

        List<TebliglerUI> GetListAnaSayfaTebliglerTab();

        new int GetMaxId();
        int GetListWithPagingCount(TebliglerFilter filter);
    }
}
