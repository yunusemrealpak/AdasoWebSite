using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class view_ortaklikManager : Iview_ortaklikService
    {
        private Iview_ortaklikDal _view_ortaklikDal;

        public view_ortaklikManager(Iview_ortaklikDal view_ortaklikDal)
        {
            _view_ortaklikDal = view_ortaklikDal;
        }

        public IDataResult<view_ortaklik> GetByIdStr(string Id)
        {
            try
            {
                return new DataResult<view_ortaklik>(_view_ortaklikDal.GetByIdStr(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<view_ortaklik>(null, false, ex.Message);
            }

        }
        public IDataResult<IList<view_ortaklik>> GetList(string id)
        {
            try
            {

                SuccessDataResult<IList<view_ortaklik>> result = new SuccessDataResult<IList<view_ortaklik>>();
                return new DataResult<IList<view_ortaklik>>(_view_ortaklikDal.GetListStrId(id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<view_ortaklik>>(null, false, ex.Message);
            }

        }

    }
}
