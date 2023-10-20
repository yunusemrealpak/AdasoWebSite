using Business.Abstract;
using Core.Aspects.Autofac.Performance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class GazetelerManager : IGazetelerService
    {
        private IGazetelerDal _gazetelerDal;

        public GazetelerManager(IGazetelerDal gazetelerDal)
        {
            _gazetelerDal = gazetelerDal;
        }

        public IResult Add(Gazeteler Gazeteler)
        {
            try
            {
                _gazetelerDal.Add(Gazeteler);
                return new DataResult<Gazeteler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Gazeteler>(null, false, ex.Message);
            }
        }

        public IResult Delete(Gazeteler Gazeteler)
        {
            try
            {
                _gazetelerDal.Delete(Gazeteler);
                return new DataResult<Gazeteler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Gazeteler>(null, false, ex.Message);
            }

        }

        public IDataResult<Gazeteler> GetById(int Id)
        {
            try
            {
                return new DataResult<Gazeteler>(_gazetelerDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Gazeteler>(null, false, ex.Message);
            }

        }

        [PerformanceAspect(3)]
        public IDataResult<IList<Gazeteler>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Gazeteler>> result = new SuccessDataResult<IList<Gazeteler>>();
                return new DataResult<IList<Gazeteler>>(_gazetelerDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Gazeteler>>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Gazeteler>> GetListHomePageMagazine()
        {
            try
            {
                var data = _gazetelerDal.GetListHomePageMagazine();

                SuccessDataResult<IList<Gazeteler>> result = new SuccessDataResult<IList<Gazeteler>>();
                return new DataResult<IList<Gazeteler>>(data, true);


            }
            catch (Exception ex)
            {
                return new DataResult<IList<Gazeteler>>(null, false, ex.Message);
            }
        }
        public IDataResult<IList<Gazeteler>> GetListWithPaging(GazetelerFilter filter)
        {

            List<Gazeteler> result = _gazetelerDal.GetListWithPaging(filter).ToList();
            return new SuccessDataResult<IList<Gazeteler>>(result) { DataCount = _gazetelerDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(GazetelerFilter filter)
        {
            return _gazetelerDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _gazetelerDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }
        public IResult Update(Gazeteler Gazeteler)
        {
            try
            {
                _gazetelerDal.Update(Gazeteler);
                SuccessDataResult<Gazeteler> result = new SuccessDataResult<Gazeteler>();
                return new DataResult<Gazeteler>(Gazeteler, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Gazeteler>(null, false, ex.Message);
            }

        }
    }
}
