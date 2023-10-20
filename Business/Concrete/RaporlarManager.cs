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
    public class RaporlarManager : IRaporlarService
    {
        private IRaporlarDal _raporlarDal;

        public RaporlarManager(IRaporlarDal raporlarDal)
        {
            _raporlarDal = raporlarDal;
        }

        public IResult Add(Raporlar Raporlar)
        {
            try
            {
                _raporlarDal.Add(Raporlar);
                return new DataResult<Raporlar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Raporlar>(null, false, ex.Message);
            }
        }

        public IResult Delete(Raporlar Raporlar)
        {
            try
            {
                _raporlarDal.Delete(Raporlar);
                return new DataResult<Raporlar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Raporlar>(null, false, ex.Message);
            }

        }

        public IDataResult<Raporlar> GetById(int Id)
        {
            try
            {
                return new DataResult<Raporlar>(_raporlarDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Raporlar>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<Raporlar>> GetList()
        {
            try
            {
                var data = _raporlarDal.GetList().ToList();

                SuccessDataResult<IList<Raporlar>> result = new SuccessDataResult<IList<Raporlar>>();
                return new DataResult<IList<Raporlar>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Raporlar>>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Raporlar>> GetRaporTipList(RaporFilter filter)
        {
            try
            {
                var data = _raporlarDal.GetRaporTipList(filter).ToList();

                return new DataResult<IList<Raporlar>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Raporlar>>(null, false, ex.Message);
            }
        }

        public IResult Update(Raporlar Raporlar)
        {
            try
            {
                _raporlarDal.Update(Raporlar);
                SuccessDataResult<Raporlar> result = new SuccessDataResult<Raporlar>();
                return new DataResult<Raporlar>(Raporlar, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Raporlar>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Raporlar>> GetListWithPaging(RaporFilter filter)
        {
            //int i = Convert.ToInt32("iso");
            //SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
            //return _yazilarDal.GetListWithPaging(skip, take, baslik).ToList();             

            List<Raporlar> result = _raporlarDal.GetListWithPaging(filter).ToList();
            //result.ForEach(x =>
            //{
            //    x.KategoriAdi = x.Grup == 1 ? "Haber" : "Duyuru";
            //});

            return new SuccessDataResult<IList<Raporlar>>(result) { DataCount = _raporlarDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(RaporFilter filter)
        {
            return _raporlarDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _raporlarDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }
    }
}