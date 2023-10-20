using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface ITebliglerService
    {
        IResult Add(Tebligler Tebligler);

        IResult Delete(Tebligler Tebligler);
        IResult DeleteById(int ID);

        IDataResult<Tebligler> GetById(int Id);

        IDataResult<IList<Tebligler>> GetList();

        IDataResult<int> GetMaxId();
        IDataResult<IList<Tebligler>> GetListWithPaging(TebliglerFilter filter);
        IDataResult<IList<TebliglerUI>> GetListAnaSayfaTebliglerTab();
        int GetListWithPagingCount(TebliglerFilter filter);

        IResult Update(Tebligler Tebligler);



    }
}

