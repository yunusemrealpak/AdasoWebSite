using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
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

        int GetListWithPagingCount(YazilarFilter filter);

        IDataResult<int> GetMaxId();
        IResult Update(Etkinlikler Etkinlikler);

    }
}

