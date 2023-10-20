using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product Product);

        IResult Delete(Product Product);

        IDataResult<Product> GetById(int Id);

        IDataResult<IList<Product>> GetList();

        IResult Update(Product Product);

    }
}

