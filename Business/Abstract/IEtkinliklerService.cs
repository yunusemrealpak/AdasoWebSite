using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IEtkinliklerService
    {
        IResult Add(Etkinlikler Etkinlikler);

        IResult Delete(Etkinlikler Etkinlikler);

        IDataResult<Etkinlikler> GetById(int Id);

        IDataResult<IList<Etkinlikler>> GetList();

        IDataResult<IList<Etkinlikler>> GetListHomePageActives(FilterFullCalendar fiter);

        IDataResult<IList<Etkinlikler>> GetListWithPaging(YazilarFilter filter);

        Task<List<Etkinlikler>> GetListAsync(int max);

        int GetListWithPagingCount(YazilarFilter filter);

        IDataResult<int> GetMaxId();
        IResult Update(Etkinlikler Etkinlikler);

    }
}

