using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BaseManager<TInjectInterface, TEntity>
        where TInjectInterface : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        TInjectInterface _service;
        public BaseManager(TInjectInterface service)
        {
            _service = service;
        }

        public IResult Add(TEntity Entity)
        {
            try
            {
                _service.Add(Entity);
                return new DataResult<TEntity>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<TEntity>(null, false, ex.Message);
            }
        }

        public IResult Delete(TEntity Entity)
        {
            try
            {
                _service.Delete(Entity);
                return new DataResult<TEntity>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<TEntity>(null, false, ex.Message);
            }

        }

        public IDataResult<TEntity> GetById(int Id)
        {
            try
            {
                return new DataResult<TEntity>(_service.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<TEntity>(null, false, ex.Message);
            }

        }


        public IDataResult<int> GetMaxId()
        {
            var data = _service.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }

        public IDataResult<IList<TEntity>> GetList()
        {
            try
            {

                SuccessDataResult<IList<TEntity>> result = new SuccessDataResult<IList<TEntity>>();
                return new DataResult<IList<TEntity>>(_service.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<TEntity>>(null, false, ex.Message);
            }

        }

        public IResult Update(TEntity Entity)
        {
            try
            {
                _service.Update(Entity);
                SuccessDataResult<TEntity> result = new SuccessDataResult<TEntity>();
                return new DataResult<TEntity>(Entity, true);
            }
            catch (Exception ex)
            {
                return new DataResult<TEntity>(null, false, ex.Message);
            }

        }
    }
}