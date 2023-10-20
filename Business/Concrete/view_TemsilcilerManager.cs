using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class view_TemsilcilerManager : Iview_TemsilcilerService
    {
        private Iview_TemsilcilerDal _view_TemsilcilerDal;

        public view_TemsilcilerManager(Iview_TemsilcilerDal view_TemsilcilerDal)
        {
            _view_TemsilcilerDal = view_TemsilcilerDal;
        }

        public IDataResult<view_Temsilciler> GetByIdStr(string Id)
        {
            try
            {
                return new DataResult<view_Temsilciler>(_view_TemsilcilerDal.GetByIdStr(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<view_Temsilciler>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<view_Temsilciler>> GetByListId(string Id)
        {
            try
            {
                SuccessDataResult<IList<view_Temsilciler>> result = new SuccessDataResult<IList<view_Temsilciler>>();
                return new DataResult<IList<view_Temsilciler>>(_view_TemsilcilerDal.GetListStrId(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<view_Temsilciler>>(null, false, ex.Message);
            }
        }
    }
}
