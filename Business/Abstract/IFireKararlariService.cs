using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IFireKararlariService
    {


        IDataResult<int> GetMaxId();
        IDataResult<FireKararlari> GetById(int Id);

        IDataResult<IList<FireKararlari>> GetList();

        IDataResult<IList<FireKararlari>> GetListWithPaging(FireKararlariFilter filter);

        int GetListWithPagingCount(FireKararlariFilter filter);

        IResult Add(FireKararlari FireKararlari);

        IResult Delete(FireKararlari FireKararlari);

        IResult DeleteById(int ID);

        IResult Update(FireKararlari FireKararlari);


    }
}

