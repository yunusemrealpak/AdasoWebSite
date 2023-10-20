using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IAnketlerService
    {
        IResult Add(Anketler Anketler);

        IResult Delete(Anketler Anketler);

        IDataResult<Anketler> GetById(int Id);

        IDataResult<IList<Anketler>> GetList();

        IResult Update(Anketler Anketler);

    }
}

