using Business.Abstract;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class KullanicilarManager : IKullanicilarService
    {
        private IKullanicilarDal _kullanicilarDal;

        public KullanicilarManager(IKullanicilarDal kullanicilarDal)
        {
            _kullanicilarDal = kullanicilarDal;
        }

        public IResult Add(Kullanicilar Kullanicilar)
        {
            try
            {
                _kullanicilarDal.Add(Kullanicilar);
                return new DataResult<Kullanicilar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Kullanicilar>(null, false, ex.Message);
            }
        }

        public IResult Delete(Kullanicilar Kullanicilar)
        {
            try
            {
                _kullanicilarDal.Delete(Kullanicilar);
                return new DataResult<Kullanicilar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Kullanicilar>(null, false, ex.Message);
            }

        }

        public IDataResult<Kullanicilar> GetById(int Id)
        {
            try
            {
                return new DataResult<Kullanicilar>(_kullanicilarDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Kullanicilar>(null, false, ex.Message);
            }

        }

        [LogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<Kullanicilar>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Kullanicilar>> result = new SuccessDataResult<IList<Kullanicilar>>();
                return new DataResult<IList<Kullanicilar>>(_kullanicilarDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Kullanicilar>>(null, false, ex.Message);
            }

        }

        public IResult Update(Kullanicilar Kullanicilar)
        {
            try
            {
                _kullanicilarDal.Update(Kullanicilar);
                SuccessDataResult<Kullanicilar> result = new SuccessDataResult<Kullanicilar>();
                return new DataResult<Kullanicilar>(Kullanicilar, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Kullanicilar>(null, false, ex.Message);
            }

        }
    }
}
