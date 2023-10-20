using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category Category)
        {
            try
            {
                _categoryDal.Add(Category);
                return new DataResult<Category>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Category>(null, false, ex.Message);
            }
        }

        public IResult Delete(Category Category)
        {
            try
            {
                _categoryDal.Delete(Category);
                return new DataResult<Category>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Category>(null, false, ex.Message);
            }

        }

        public IDataResult<Category> GetById(int Id)
        {
            try
            {
                return new DataResult<Category>(_categoryDal.Get(x => x.CategoryId == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Category>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Category>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Category>> result = new SuccessDataResult<IList<Category>>();
                return new DataResult<IList<Category>>(_categoryDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Category>>(null, false, ex.Message);
            }

        }

        public IResult Update(Category Category)
        {
            try
            {
                _categoryDal.Update(Category);
                SuccessDataResult<Category> result = new SuccessDataResult<Category>();
                return new DataResult<Category>(Category, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Category>(null, false, ex.Message);
            }

        }
    }
}
