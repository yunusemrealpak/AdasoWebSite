using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IProjelerService
    {
        IResult Add(Projeler Projeler);

        IResult Delete(Projeler Projeler);

        IDataResult<Projeler> GetById(int Id);

        IDataResult<IList<Projeler>> GetList();
        IDataResult<IList<Projeler>> GetListWithPaging(YazilarFilter filter);
        int GetListWithPagingCount(YazilarFilter filter);

        IDataResult<int> GetMaxId();
        IResult Update(Projeler Projeler);

    }
}

