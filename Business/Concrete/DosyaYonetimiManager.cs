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
    public class DosyaYonetimiManager : IDosyaYonetimiService
    {
        private IDosyaYonetimiDal _DosyaYonetimiDal;

        public DosyaYonetimiManager(IDosyaYonetimiDal DosyaYonetimiDal)
        {
            _DosyaYonetimiDal = DosyaYonetimiDal;
        }

        public IResult Add(DosyaYonetimi DosyaYonetimi)
        {
            try
            {
                _DosyaYonetimiDal.Add(DosyaYonetimi);
                return new DataResult<DosyaYonetimi>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<DosyaYonetimi>(null, false, ex.Message);
            }
        }

        public IResult Delete(DosyaYonetimi DosyaYonetimi)
        {
            try
            {
                _DosyaYonetimiDal.Delete(DosyaYonetimi);
                return new DataResult<DosyaYonetimi>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<DosyaYonetimi>(null, false, ex.Message);
            }

        }
        public IResult DeleteById(int ID)
        {
            try
            {

                //File.Delete(filepath);
                //_DosyaYonetimiDal.DeleteById(ID);

                _DosyaYonetimiDal.DeleteById(ID);

                return new DataResult<DosyaYonetimi>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<DosyaYonetimi>(null, false, ex.Message);
            }
        }
        public IDataResult<DosyaYonetimi> GetById(int Id)
        {
            try
            {
                return new DataResult<DosyaYonetimi>(_DosyaYonetimiDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<DosyaYonetimi>(null, false, ex.Message);
            }
        }
        public IDataResult<IList<DosyaYonetimi>> GetList()
        {
            try
            {
                var data = _DosyaYonetimiDal.GetList().ToList();

                SuccessDataResult<IList<DosyaYonetimi>> result = new SuccessDataResult<IList<DosyaYonetimi>>();
                return new DataResult<IList<DosyaYonetimi>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<DosyaYonetimi>>(null, false, ex.Message);
            }

        }

        //[CacheAspect()]
        //[LogAspect(typeof(DatabaseLogger))]
        //[ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<DosyaYonetimi>> GetListWithPaging(DosyaYonetimiFilter filter)
        {

            List<DosyaYonetimi> result = _DosyaYonetimiDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<DosyaYonetimi>>(result) { DataCount = _DosyaYonetimiDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(DosyaYonetimiFilter filter)
        {
            return _DosyaYonetimiDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _DosyaYonetimiDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }

        public IResult Update(DosyaYonetimi DosyaYonetimi)
        {
            try
            {
                _DosyaYonetimiDal.Update(DosyaYonetimi);
                SuccessDataResult<DosyaYonetimi> result = new SuccessDataResult<DosyaYonetimi>();
                return new DataResult<DosyaYonetimi>(DosyaYonetimi, true);
            }
            catch (Exception ex)
            {
                return new DataResult<DosyaYonetimi>(null, false, ex.Message);
            }

        }
    }
}