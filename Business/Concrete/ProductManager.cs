using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product Product)
        {
            try
            {
                _productDal.Add(Product);
                return new DataResult<Product>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Product>(null, false, ex.Message);
            }
        }

        public IResult Delete(Product Product)
        {
            try
            {
                _productDal.Delete(Product);
                return new DataResult<Product>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Product>(null, false, ex.Message);
            }

        }

        public IDataResult<Product> GetById(int Id)
        {
            try
            {
                return new DataResult<Product>(_productDal.Get(x => x.ProductId == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Product>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Product>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Product>> result = new SuccessDataResult<IList<Product>>();
                return new DataResult<IList<Product>>(_productDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Product>>(null, false, ex.Message);
            }

        }

        public IResult Update(Product Product)
        {
            try
            {
                _productDal.Update(Product);
                SuccessDataResult<Product> result = new SuccessDataResult<Product>();
                return new DataResult<Product>(Product, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Product>(null, false, ex.Message);
            }

        }
    }
}
