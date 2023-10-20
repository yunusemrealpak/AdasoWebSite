using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class EIPManager : IEIPService
    {
        private IEIPDal _eIPDal;

        public EIPManager(IEIPDal eIPDal)
        {
            _eIPDal = eIPDal;
        }

        public IResult Add(EIP EIP)
        {
            try
            {
                _eIPDal.Add(EIP);
                return new DataResult<EIP>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<EIP>(null, false, ex.Message);
            }
        }

        public IResult Delete(EIP EIP)
        {
            try
            {
                _eIPDal.Delete(EIP);
                return new DataResult<EIP>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<EIP>(null, false, ex.Message);
            }

        }

        public IDataResult<EIP> GetById(int Id)
        {
            try
            {
                return new DataResult<EIP>(_eIPDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<EIP>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<EIP>> GetList()
        {
            try
            {

                SuccessDataResult<IList<EIP>> result = new SuccessDataResult<IList<EIP>>();
                return new DataResult<IList<EIP>>(_eIPDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<EIP>>(null, false, ex.Message);
            }

        }

        public IResult Update(EIP EIP)
        {
            try
            {
                _eIPDal.Update(EIP);
                SuccessDataResult<EIP> result = new SuccessDataResult<EIP>();
                return new DataResult<EIP>(EIP, true);
            }
            catch (Exception ex)
            {
                return new DataResult<EIP>(null, false, ex.Message);
            }

        }
    }
}
