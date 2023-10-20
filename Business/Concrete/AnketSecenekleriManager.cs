using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class AnketSecenekleriManager : IAnketSecenekleriService
    {
        private IAnketSecenekleriDal _anketSecenekleriDal;

        public AnketSecenekleriManager(IAnketSecenekleriDal anketSecenekleriDal)
        {
            _anketSecenekleriDal = anketSecenekleriDal;
        }

        public IResult Add(AnketSecenekleri AnketSecenekleri)
        {
            try
            {
                _anketSecenekleriDal.Add(AnketSecenekleri);
                return new DataResult<AnketSecenekleri>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<AnketSecenekleri>(null, false, ex.Message);
            }
        }

        public IResult Delete(AnketSecenekleri AnketSecenekleri)
        {
            try
            {
                _anketSecenekleriDal.Delete(AnketSecenekleri);
                return new DataResult<AnketSecenekleri>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<AnketSecenekleri>(null, false, ex.Message);
            }

        }

        public IDataResult<AnketSecenekleri> GetById(int Id)
        {
            try
            {
                return new DataResult<AnketSecenekleri>(_anketSecenekleriDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<AnketSecenekleri>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<AnketSecenekleri>> GetList()
        {
            try
            {

                SuccessDataResult<IList<AnketSecenekleri>> result = new SuccessDataResult<IList<AnketSecenekleri>>();
                return new DataResult<IList<AnketSecenekleri>>(_anketSecenekleriDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<AnketSecenekleri>>(null, false, ex.Message);
            }

        }

        public IResult Update(AnketSecenekleri AnketSecenekleri)
        {
            try
            {
                _anketSecenekleriDal.Update(AnketSecenekleri);
                SuccessDataResult<AnketSecenekleri> result = new SuccessDataResult<AnketSecenekleri>();
                return new DataResult<AnketSecenekleri>(AnketSecenekleri, true);
            }
            catch (Exception ex)
            {
                return new DataResult<AnketSecenekleri>(null, false, ex.Message);
            }

        }
    }
}
