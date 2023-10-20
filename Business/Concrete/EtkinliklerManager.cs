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
    public class EtkinliklerManager : IEtkinliklerService
    {
        private IEtkinliklerDal _etkinliklerDal;

        public EtkinliklerManager(IEtkinliklerDal etkinliklerDal)
        {
            _etkinliklerDal = etkinliklerDal;
        }

        public IResult Add(Etkinlikler Etkinlikler)
        {
            try
            {
                _etkinliklerDal.Add(Etkinlikler);
                return new DataResult<Etkinlikler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Etkinlikler>(null, false, ex.Message);
            }
        }

        public IResult Delete(Etkinlikler Etkinlikler)
        {
            try
            {
                _etkinliklerDal.Delete(Etkinlikler);
                return new DataResult<Etkinlikler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Etkinlikler>(null, false, ex.Message);
            }

        }

        public IDataResult<Etkinlikler> GetById(int Id)
        {
            try
            {
                return new DataResult<Etkinlikler>(_etkinliklerDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Etkinlikler>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Etkinlikler>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Etkinlikler>> result = new SuccessDataResult<IList<Etkinlikler>>();
                return new DataResult<IList<Etkinlikler>>(_etkinliklerDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Etkinlikler>>(null, false, ex.Message);
            }

        }
        public IDataResult<IList<Etkinlikler>> GetListHomePageActives(FilterFullCalendar filter)
        {
            try
            {
                var data = _etkinliklerDal.GetListHomePageActives(filter);

                SuccessDataResult<IList<Etkinlikler>> result = new SuccessDataResult<IList<Etkinlikler>>();
                return new DataResult<IList<Etkinlikler>>(data, true);



            }
            catch (Exception ex)
            {
                return new DataResult<IList<Etkinlikler>>(null, false, ex.Message);

            }

        }

        public IDataResult<IList<Etkinlikler>> GetListWithPaging(YazilarFilter filter)
        {
            //int i = Convert.ToInt32("iso");
            //SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
            //return _yazilarDal.GetListWithPaging(skip, take, baslik).ToList();             

            List<Etkinlikler> result = _etkinliklerDal.GetListWithPaging(filter).ToList();
            //result.ForEach(x =>
            //{
            //    x.KategoriAdi = x.Grup == 1 ? "Haber" : "Duyuru";
            //});

            return new SuccessDataResult<IList<Etkinlikler>>(result) { DataCount = _etkinliklerDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(YazilarFilter filter)
        {
            return _etkinliklerDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _etkinliklerDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }

        public IResult Update(Etkinlikler Etkinlikler)
        {
            try
            {
                _etkinliklerDal.Update(Etkinlikler);
                SuccessDataResult<Etkinlikler> result = new SuccessDataResult<Etkinlikler>();
                return new DataResult<Etkinlikler>(Etkinlikler, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Etkinlikler>(null, false, ex.Message);
            }

        }
    }
}
