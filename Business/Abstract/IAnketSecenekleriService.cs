using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IAnketSecenekleriService
    {
        IResult Add(AnketSecenekleri AnketSecenekleri);

        IResult Delete(AnketSecenekleri AnketSecenekleri);

        IDataResult<AnketSecenekleri> GetById(int Id);

        IDataResult<IList<AnketSecenekleri>> GetList();

        IResult Update(AnketSecenekleri AnketSecenekleri);

    }
}

