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
    public class MKUyelerManager : IMKUyelerService
    {
        private IMKUyelerDal _mKUyelerDal;

        public MKUyelerManager(IMKUyelerDal mKUyelerDal)
        {
            _mKUyelerDal = mKUyelerDal;
        }

        public IDataResult<MKUyeler> GetById(int Id)
        {
            try
            {
                return new DataResult<MKUyeler>(_mKUyelerDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<MKUyeler>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<MKUyeler>> GetList()
        {
            try
            {
                var data = _mKUyelerDal.GetList().ToList();

                SuccessDataResult<IList<MKUyeler>> result = new SuccessDataResult<IList<MKUyeler>>();
                return new DataResult<IList<MKUyeler>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<MKUyeler>>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<MKUyeler>> GetListWithPaging(MkUyelerFilter filter)
        {
            List<MKUyeler> result = _mKUyelerDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<MKUyeler>>(result) { DataCount = _mKUyelerDal.GetListWithPagingCount(filter) };
        }

        public int GetListWithPagingCount(MkUyelerFilter filter)
        {
            return _mKUyelerDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            throw new NotImplementedException();
        }
    }
}
