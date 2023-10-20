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
    public class SunumlarManager : ISunumlarService
    {
        private ISunumlarDal _SunumlarDal;


        public SunumlarManager(ISunumlarDal SunumlarDal)
        {
            _SunumlarDal = SunumlarDal;
        }

        public IResult Add(Sunumlar Sunumlar)
        {
            try
            {
                _SunumlarDal.Add(Sunumlar);
                _SunumlarDal.SP_Add("Proc_Crs_Sunumlar_Sonuc");
                return new DataResult<Sunumlar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sunumlar>(null, false, ex.Message);
            }
        }

        public IResult Delete(Sunumlar Sunumlar)
        {
            try
            {
                _SunumlarDal.Delete(Sunumlar);
                _SunumlarDal.SP_Add("Proc_Crs_Sunumlar_Sonuc");
                return new DataResult<Sunumlar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sunumlar>(null, false, ex.Message);
            }

        }


        public IDataResult<Sunumlar> GetById(int Id)
        {
            try
            {
                return new DataResult<Sunumlar>(_SunumlarDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sunumlar>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<Sunumlar>> GetList()
        {
            try
            {
                var data = _SunumlarDal.GetList().ToList();

                SuccessDataResult<IList<Sunumlar>> result = new SuccessDataResult<IList<Sunumlar>>();
                return new DataResult<IList<Sunumlar>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Sunumlar>>(null, false, ex.Message);
            }

        }

        //[CacheAspect()]
        //[LogAspect(typeof(DatabaseLogger))]
        //[ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<Sunumlar>> GetListWithPaging(SunumlarFilter filter)
        {

            List<Sunumlar> result = _SunumlarDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<Sunumlar>>(result) { DataCount = _SunumlarDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(SunumlarFilter filter)
        {
            return _SunumlarDal.GetListWithPagingCount(filter);
        }



        public IDataResult<int> GetMaxId()
        {
            var data = _SunumlarDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }

        public IResult Update(Sunumlar Sunumlar)
        {
            try
            {
                _SunumlarDal.Update(Sunumlar);
                _SunumlarDal.SP_Add("Proc_Crs_Sunumlar_Sonuc");
                SuccessDataResult<Sunumlar> result = new SuccessDataResult<Sunumlar>();
                return new DataResult<Sunumlar>(Sunumlar, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sunumlar>(null, false, ex.Message);
            }

        }


    }
}