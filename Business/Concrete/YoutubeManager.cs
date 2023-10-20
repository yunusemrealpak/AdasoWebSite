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
    public class YoutubeManager : IYoutubeService
    {
        private IYoutubeDal _youtubeDal;

        public YoutubeManager(IYoutubeDal youtubeDal)
        {
            _youtubeDal = youtubeDal;
        }

        public IResult Add(Youtube Youtube)
        {
            try
            {
                _youtubeDal.Add(Youtube);
                return new DataResult<Youtube>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Youtube>(null, false, ex.Message);
            }
        }

        public IResult Delete(Youtube Youtube)
        {
            try
            {
                _youtubeDal.Delete(Youtube);
                return new DataResult<Youtube>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Youtube>(null, false, ex.Message);
            }

        }


        public IDataResult<Youtube> GetById(int Id)
        {
            try
            {
                return new DataResult<Youtube>(_youtubeDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Youtube>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<Youtube>> GetList()
        {
            try
            {
                var data = _youtubeDal.GetList().ToList();

                SuccessDataResult<IList<Youtube>> result = new SuccessDataResult<IList<Youtube>>();
                return new DataResult<IList<Youtube>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Youtube>>(null, false, ex.Message);
            }

        }

        //[CacheAspect()]
        //[LogAspect(typeof(DatabaseLogger))]
        //[ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<Youtube>> GetListWithPaging(YoutubeFilter filter)
        {

            List<Youtube> result = _youtubeDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<Youtube>>(result) { DataCount = _youtubeDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(YoutubeFilter filter)
        {
            return _youtubeDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _youtubeDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }

        public IResult Update(Youtube Youtube)
        {
            try
            {
                _youtubeDal.Update(Youtube);
                SuccessDataResult<Youtube> result = new SuccessDataResult<Youtube>();
                return new DataResult<Youtube>(Youtube, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Youtube>(null, false, ex.Message);
            }

        }


    }
}