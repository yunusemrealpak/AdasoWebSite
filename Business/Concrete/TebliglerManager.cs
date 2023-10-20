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
    public class TebliglerManager : ITebliglerService
    {
        private ITebliglerDal _tebliglerDal;

        public TebliglerManager(ITebliglerDal tebliglerDal)
        {
            _tebliglerDal = tebliglerDal;
        }

        public IResult Add(Tebligler Tebligler)
        {
            try
            {
                _tebliglerDal.Add(Tebligler);
                return new DataResult<Tebligler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Tebligler>(null, false, ex.Message);
            }
        }

        public IResult Delete(Tebligler Tebligler)
        {
            try
            {
                _tebliglerDal.Delete(Tebligler);
                return new DataResult<Tebligler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Tebligler>(null, false, ex.Message);
            }

        }
        public IResult DeleteById(int ID)
        {
            try
            {
                _tebliglerDal.DeleteById(ID);
                return new DataResult<Tebligler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Tebligler>(null, false, ex.Message);
            }

        }
        //public IDataResult<Tebligler> GetById(int Id)
        //{
        //    try
        //    {
        //        return new DataResult<Tebligler>(_tebliglerDal.Get(x => x.ID == Id), true);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new DataResult<Tebligler>(null, false, ex.Message);
        //    }
        //}
        public IDataResult<Tebligler> GetById(int Id)
        {
            Tebligler result = _tebliglerDal.Get(x => x.ID == Id);

            return new SuccessDataResult<Tebligler>(result) { DataCount = result != null ? 1 : 0 };
        }

        public IDataResult<IList<Tebligler>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Tebligler>> result = new SuccessDataResult<IList<Tebligler>>();
                return new DataResult<IList<Tebligler>>(_tebliglerDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Tebligler>>(null, false, ex.Message);
            }

        }


        public IDataResult<int> GetMaxId()
        {
            var data = _tebliglerDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }
        public IDataResult<IList<TebliglerUI>> GetListAnaSayfaTebliglerTab()
        {
            try
            {
                SuccessDataResult<IList<TebliglerUI>> result = new SuccessDataResult<IList<TebliglerUI>>();
                return new DataResult<IList<TebliglerUI>>(_tebliglerDal.GetListAnaSayfaTebliglerTab(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<TebliglerUI>>(null, false, ex.Message);
            }

        }

        //[LogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<Tebligler>> GetListWithPaging(TebliglerFilter filter)
        {

            List<Tebligler> result = _tebliglerDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<Tebligler>>(result) { DataCount = _tebliglerDal.GetListWithPagingCount(filter) };
            //try
            //{
            //    SuccessDataResult<IList<Tebligler>> result = new SuccessDataResult<IList<Tebligler>>();
            //    return new SuccessDataResult<IList<Tebligler>>(_tebliglerDal.GetListWithPaging(filter).ToList()) { DataCount = _tebliglerDal.GetListWithPagingCount(filter) };
            //}
            //catch (Exception ex)
            //{
            //    return new ErrorDataResult<IList<Tebligler>>(null, ex.Message);
            //}

        }

        public int GetListWithPagingCount(TebliglerFilter filter)
        {
            return _tebliglerDal.GetListWithPagingCount(filter);
        }

        public IResult Update(Tebligler Tebligler)
        {
            try
            {
                _tebliglerDal.Update(Tebligler);
                SuccessDataResult<Tebligler> result = new SuccessDataResult<Tebligler>();
                return new DataResult<Tebligler>(Tebligler, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Tebligler>(null, false, ex.Message);
            }

        }

    }
}
