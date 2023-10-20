using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IDosyaYonetimiDal : IEntityRepository<DosyaYonetimi>
    {
        List<DosyaYonetimi> GetListWithPaging(DosyaYonetimiFilter filter);
        int GetListWithPagingCount(DosyaYonetimiFilter filter);

    }
}
