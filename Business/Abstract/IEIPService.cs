using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IEIPService
    {
        IResult Add(EIP EIP);

        IResult Delete(EIP EIP);

        IDataResult<EIP> GetById(int Id);

        IDataResult<IList<EIP>> GetList();

        IResult Update(EIP EIP);

    }
}

