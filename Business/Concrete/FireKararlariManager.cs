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
    public class FireKararlariManager : IFireKararlariService
    {
        private IFireKararlariDal _fireKararlariDal;
        public FireKararlariManager(IFireKararlariDal fireKararlariDal)
        {
            _fireKararlariDal = fireKararlariDal;
        }
        public IResult Add(FireKararlari FireKararlari)
        {
            try
            {
                _fireKararlariDal.Add(FireKararlari);
                return new DataResult<FireKararlari>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<FireKararlari>(null, false, ex.Message);
            }
        }
        public IResult Delete(FireKararlari FireKararlari)
        {
            try
            {
                _fireKararlariDal.Delete(FireKararlari);
                return new DataResult<FireKararlari>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<FireKararlari>(null, false, ex.Message);
            }

        }
        public IDataResult<FireKararlari> GetById(int Id)
        {
            try
            {
                return new DataResult<FireKararlari>(_fireKararlariDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<FireKararlari>(null, false, ex.Message);
            }

        }
        public IDataResult<IList<FireKararlari>> GetListWithPaging(FireKararlariFilter filter)
        {

            List<FireKararlari> result = _fireKararlariDal.GetListWithPaging(filter).ToList();
            return new SuccessDataResult<IList<FireKararlari>>(result) { DataCount = _fireKararlariDal.GetListWithPagingCount(filter) };

        }
        public int GetListWithPagingCount(FireKararlariFilter filter)
        {
            return _fireKararlariDal.GetListWithPagingCount(filter);
        }
        public IDataResult<int> GetMaxId()
        {
            var data = _fireKararlariDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }
        public IDataResult<IList<FireKararlari>> GetList()
        {
            try
            {

                SuccessDataResult<IList<FireKararlari>> result = new SuccessDataResult<IList<FireKararlari>>();
                return new DataResult<IList<FireKararlari>>(_fireKararlariDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<FireKararlari>>(null, false, ex.Message);
            }

        }
        public IResult Update(FireKararlari FireKararlari)
        {
            try
            {
                _fireKararlariDal.Update(FireKararlari);
                SuccessDataResult<FireKararlari> result = new SuccessDataResult<FireKararlari>();
                return new DataResult<FireKararlari>(FireKararlari, true);
            }
            catch (Exception ex)
            {
                return new DataResult<FireKararlari>(null, false, ex.Message);
            }

        }
        public IResult DeleteById(int ID)
        {
            try
            {
                _fireKararlariDal.DeleteById(ID);
                return new DataResult<DosyaYonetimi>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<DosyaYonetimi>(null, false, ex.Message);
            }
        }
    }
}
