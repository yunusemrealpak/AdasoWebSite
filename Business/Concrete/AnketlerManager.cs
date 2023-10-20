using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class AnketlerManager : IAnketlerService
    {
        private IAnketlerDal _anketlerDal;

        public AnketlerManager(IAnketlerDal anketlerDal)
        {
            _anketlerDal = anketlerDal;
        }

        public IResult Add(Anketler Anketler)
        {
            try
            {
                _anketlerDal.Add(Anketler);
                return new DataResult<Anketler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Anketler>(null, false, ex.Message);
            }
        }

        public IResult Delete(Anketler Anketler)
        {
            try
            {
                _anketlerDal.Delete(Anketler);
                return new DataResult<Anketler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Anketler>(null, false, ex.Message);
            }

        }

        public IDataResult<Anketler> GetById(int Id)
        {
            try
            {
                return new DataResult<Anketler>(_anketlerDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Anketler>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Anketler>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Anketler>> result = new SuccessDataResult<IList<Anketler>>();
                return new DataResult<IList<Anketler>>(_anketlerDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Anketler>>(null, false, ex.Message);
            }

        }

        public IResult Update(Anketler Anketler)
        {
            try
            {
                _anketlerDal.Update(Anketler);
                SuccessDataResult<Anketler> result = new SuccessDataResult<Anketler>();
                return new DataResult<Anketler>(Anketler, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Anketler>(null, false, ex.Message);
            }

        }
    }
}
