using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category Category);

        IResult Delete(Category Category);

        IDataResult<Category> GetById(int Id);

        IDataResult<IList<Category>> GetList();

        IResult Update(Category Category);

    }
}

