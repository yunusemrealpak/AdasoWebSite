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
    public class View_Base_OFirmalarManager : IView_Base_OFirmalarService
    {
        private IView_Base_OFirmalarDal _View_Base_OFirmalarDal;

        public View_Base_OFirmalarManager(IView_Base_OFirmalarDal View_Base_OFirmalarDal)
        {
            _View_Base_OFirmalarDal = View_Base_OFirmalarDal;
        }

        public IDataResult<View_Base_OFirmalar> GetByIdStr(string Id)
        {
            try
            {
                return new DataResult<View_Base_OFirmalar>(_View_Base_OFirmalarDal.GetByIdStr(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<View_Base_OFirmalar>(null, false, ex.Message);
            }

        }

        public IDataResult<int> GetMaxId()
        {
            throw new NotImplementedException();
        }
        public IDataResult<IList<View_Base_OFirmalar>> GetList()
        {
            try
            {

                SuccessDataResult<IList<View_Base_OFirmalar>> result = new SuccessDataResult<IList<View_Base_OFirmalar>>();
                return new DataResult<IList<View_Base_OFirmalar>>(_View_Base_OFirmalarDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<View_Base_OFirmalar>>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<View_Base_OFirmalar>> GetListWithPaging(firmalarFilter filter)
        {
            List<View_Base_OFirmalar> result = _View_Base_OFirmalarDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<View_Base_OFirmalar>>(result) { DataCount = _View_Base_OFirmalarDal.GetListWithPagingCount(filter) };
        }

        public int GetListWithPagingCount(firmalarFilter filter)
        {
            return _View_Base_OFirmalarDal.GetListWithPagingCount(filter);
        }
    }
}
