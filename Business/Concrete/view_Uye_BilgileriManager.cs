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
    public class view_Uye_BilgileriManager : Iview_Uye_BilgileriService
    {
        private Iview_Uye_BilgileriDal _view_Uye_BilgileriDal;

        public view_Uye_BilgileriManager(Iview_Uye_BilgileriDal view_Uye_BilgileriDal)
        {
            _view_Uye_BilgileriDal = view_Uye_BilgileriDal;
        }

        public IDataResult<view_Uye_Bilgileri> GetByIdStr(string Id)
        {
            try
            {
                return new DataResult<view_Uye_Bilgileri>(_view_Uye_BilgileriDal.GetByIdStr(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<view_Uye_Bilgileri>(null, false, ex.Message);
            }

        }

        public IDataResult<int> GetMaxId()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IList<view_Uye_Bilgileri>> GetList()
        {
            try
            {
                SuccessDataResult<IList<view_Uye_Bilgileri>> result = new SuccessDataResult<IList<view_Uye_Bilgileri>>();
                return new DataResult<IList<view_Uye_Bilgileri>>(_view_Uye_BilgileriDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<view_Uye_Bilgileri>>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<view_Uye_Bilgileri>> GetListWithPaging(firmalarFilter filter)
        {
            List<view_Uye_Bilgileri> result = _view_Uye_BilgileriDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<view_Uye_Bilgileri>>(result) { DataCount = _view_Uye_BilgileriDal.GetListWithPagingCount(filter) };
        }

        public int GetListWithPagingCount(firmalarFilter filter)
        {
            return _view_Uye_BilgileriDal.GetListWithPagingCount(filter);
        }
    }
}
