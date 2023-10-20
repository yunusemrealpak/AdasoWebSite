using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class BaglantilarManager : IBaglantilarService
    {
        private IBaglantilarDal _baglantilarDal;

        public BaglantilarManager(IBaglantilarDal baglantilarDal)
        {
            _baglantilarDal = baglantilarDal;
        }

        public IResult Add(Baglantilar Baglantilar)
        {
            try
            {
                _baglantilarDal.Add(Baglantilar);
                return new DataResult<Baglantilar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Baglantilar>(null, false, ex.Message);
            }
        }

        public IResult Delete(Baglantilar Baglantilar)
        {
            try
            {
                _baglantilarDal.Delete(Baglantilar);
                return new DataResult<Baglantilar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Baglantilar>(null, false, ex.Message);
            }

        }

        public IDataResult<Baglantilar> GetById(int Id)
        {
            try
            {
                return new DataResult<Baglantilar>(_baglantilarDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Baglantilar>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Baglantilar>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Baglantilar>> result = new SuccessDataResult<IList<Baglantilar>>();
                return new DataResult<IList<Baglantilar>>(_baglantilarDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Baglantilar>>(null, false, ex.Message);
            }

        }

        public IResult Update(Baglantilar Baglantilar)
        {
            try
            {
                _baglantilarDal.Update(Baglantilar);
                SuccessDataResult<Baglantilar> result = new SuccessDataResult<Baglantilar>();
                return new DataResult<Baglantilar>(Baglantilar, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Baglantilar>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Baglantilar>> GetListWithPaging(BaglantilarFilter filter)
        {

            List<Baglantilar> result = _baglantilarDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<Baglantilar>>(result) { DataCount = _baglantilarDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(BaglantilarFilter filter)
        {
            return _baglantilarDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _baglantilarDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }
    }
}
