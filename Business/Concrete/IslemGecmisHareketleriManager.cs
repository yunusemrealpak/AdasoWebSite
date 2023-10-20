using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class IslemGecmisHareketleriManager : IIslemGecmisHareketleriService
    {
        private IIslemGecmisHareketleriDal _ıslemGecmisHareketleriDal;

        public IslemGecmisHareketleriManager(IIslemGecmisHareketleriDal ıslemGecmisHareketleriDal)
        {
            _ıslemGecmisHareketleriDal = ıslemGecmisHareketleriDal;
        }

        public IResult Add(IslemGecmisHareketleri IslemGecmisHareketleri)
        {
            try
            {
                _ıslemGecmisHareketleriDal.Add(IslemGecmisHareketleri);
                return new DataResult<IslemGecmisHareketleri>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IslemGecmisHareketleri>(null, false, ex.Message);
            }
        }

        public IResult Delete(IslemGecmisHareketleri IslemGecmisHareketleri)
        {
            try
            {
                _ıslemGecmisHareketleriDal.Delete(IslemGecmisHareketleri);
                return new DataResult<IslemGecmisHareketleri>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IslemGecmisHareketleri>(null, false, ex.Message);
            }

        }

        public IDataResult<IslemGecmisHareketleri> GetById(int Id)
        {
            try
            {
                return new DataResult<IslemGecmisHareketleri>(_ıslemGecmisHareketleriDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IslemGecmisHareketleri>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<IslemGecmisHareketleri>> GetList()
        {
            try
            {

                SuccessDataResult<IList<IslemGecmisHareketleri>> result = new SuccessDataResult<IList<IslemGecmisHareketleri>>();
                return new DataResult<IList<IslemGecmisHareketleri>>(_ıslemGecmisHareketleriDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<IslemGecmisHareketleri>>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<IslemGecmisHareketleri>> GetTableList(int id)
        {
            try
            {

                SuccessDataResult<IList<IslemGecmisHareketleri>> result = new SuccessDataResult<IList<IslemGecmisHareketleri>>();
                return new DataResult<IList<IslemGecmisHareketleri>>(_ıslemGecmisHareketleriDal.GetTableList(id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<IslemGecmisHareketleri>>(null, false, ex.Message);
            }

        }

        public IResult Update(IslemGecmisHareketleri IslemGecmisHareketleri)
        {
            try
            {
                _ıslemGecmisHareketleriDal.Update(IslemGecmisHareketleri);
                SuccessDataResult<IslemGecmisHareketleri> result = new SuccessDataResult<IslemGecmisHareketleri>();
                return new DataResult<IslemGecmisHareketleri>(IslemGecmisHareketleri, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IslemGecmisHareketleri>(null, false, ex.Message);
            }

        }
    }
}
