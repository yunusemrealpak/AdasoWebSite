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
    public class view_MeslekGruplariManager : Iview_MeslekGruplariService
    {
        private Iview_MeslekGruplariDal _view_MeslekGruplariDal;

        public view_MeslekGruplariManager(Iview_MeslekGruplariDal view_MeslekGruplariDal)
        {
            _view_MeslekGruplariDal = view_MeslekGruplariDal;
        }

        public IDataResult<view_MeslekGruplari> GetByIdStr(string Id)
        {
            try
            {
                return new DataResult<view_MeslekGruplari>(_view_MeslekGruplariDal.GetByIdStr(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<view_MeslekGruplari>(null, false, ex.Message);
            }

        }

        public IDataResult<int> GetMaxId()
        {
            throw new NotImplementedException();
        }
        public IDataResult<IList<view_MeslekGruplari>> GetList()
        {
            try
            {

                SuccessDataResult<IList<view_MeslekGruplari>> result = new SuccessDataResult<IList<view_MeslekGruplari>>();
                return new DataResult<IList<view_MeslekGruplari>>(_view_MeslekGruplariDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<view_MeslekGruplari>>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<view_MeslekGruplari>> GetListWithPaging(firmalarFilter filter)
        {
            List<view_MeslekGruplari> result = _view_MeslekGruplariDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<view_MeslekGruplari>>(result) { DataCount = _view_MeslekGruplariDal.GetListWithPagingCount(filter) };
        }

        public int GetListWithPagingCount(firmalarFilter filter)
        {
            return _view_MeslekGruplariDal.GetListWithPagingCount(filter);
        }
    }
}
