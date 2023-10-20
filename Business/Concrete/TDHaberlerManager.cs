using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class TDHaberlerManager : ITDHaberlerService
    {
        private ITDHaberlerDal _tDHaberlerDal;

        public TDHaberlerManager(ITDHaberlerDal tDHaberlerDal)
        {
            _tDHaberlerDal = tDHaberlerDal;
        }

        public IResult Add(TDHaberler TDHaberler)
        {
            try
            {
                _tDHaberlerDal.Add(TDHaberler);
                return new DataResult<TDHaberler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<TDHaberler>(null, false, ex.Message);
            }
        }

        public IResult Delete(TDHaberler TDHaberler)
        {
            try
            {
                _tDHaberlerDal.Delete(TDHaberler);
                return new DataResult<TDHaberler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<TDHaberler>(null, false, ex.Message);
            }

        }

        public IDataResult<TDHaberler> GetById(int Id)
        {
            try
            {
                return new DataResult<TDHaberler>(_tDHaberlerDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<TDHaberler>(null, false, ex.Message);
            }

        }
        public IDataResult<IList<TDHaberler>> GetListWithPaging(YazilarFilter filter)
        {
            //int i = Convert.ToInt32("iso");
            //SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
            //return _yazilarDal.GetListWithPaging(skip, take, baslik).ToList();             

            List<TDHaberler> result = _tDHaberlerDal.GetListWithPaging(filter).ToList();
            result.ForEach(x =>
            {
                x.Tip_ = x.Tip.ToString() == "1" ? "Türkiyeden Haberler" : x.Tip.ToString() == "2" ? "Dünyadan Haberler" : "AB Haberleri";
            });


            return new SuccessDataResult<IList<TDHaberler>>(result) { DataCount = _tDHaberlerDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(YazilarFilter filter)
        {
            return _tDHaberlerDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _tDHaberlerDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }
        public IDataResult<IList<TDHaberler>> GetList()
        {
            try
            {
                SuccessDataResult<IList<TDHaberler>> result = new SuccessDataResult<IList<TDHaberler>>();
                return new DataResult<IList<TDHaberler>>(_tDHaberlerDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<TDHaberler>>(null, false, ex.Message);
            }

        }

        public IResult GetListHaberDto(int Id)
        {
            try
            {
                SuccessDataResult<DenemeDto> result = new SuccessDataResult<DenemeDto>();
                result.Data.Haber = _tDHaberlerDal.Get(x => x.ID == Id);
                result.Data.Haberler = _tDHaberlerDal.GetList(x => x.Sil == false).ToList();
                return result;
            }
            catch (Exception ex)
            {
                return new DataResult<DenemeDto>(null, false, ex.Message);
            }
        }

        public IResult Update(TDHaberler TDHaberler)
        {
            try
            {
                _tDHaberlerDal.Update(TDHaberler);
                SuccessDataResult<TDHaberler> result = new SuccessDataResult<TDHaberler>();
                return new DataResult<TDHaberler>(TDHaberler, true);
            }
            catch (Exception ex)
            {
                return new DataResult<TDHaberler>(null, false, ex.Message);
            }

        }
    }
}
