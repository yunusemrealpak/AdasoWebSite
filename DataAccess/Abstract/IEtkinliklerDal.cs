using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IEtkinliklerDal : IEntityRepository<Etkinlikler>
    {
        List<Etkinlikler> GetListHomePageActives(FilterFullCalendar fiter);
        List<Etkinlikler> GetListWithPaging(YazilarFilter filter);
        List<Etkinlikler> GetListWithSize(int max);
        int GetListWithPagingCount(YazilarFilter filter);
        new int GetMaxId();
        //List<Etkinlikler> GetListHomePageActivesCalendar();

    }
}
