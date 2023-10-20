using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class AlbumGorselleriManager : IAlbumGorselleriService
    {
        private IAlbumGorselleriDal _albumGorselleriDal;

        public AlbumGorselleriManager(IAlbumGorselleriDal albumGorselleriDal)
        {
            _albumGorselleriDal = albumGorselleriDal;
        }

        public IResult Add(AlbumGorselleri AlbumGorselleri)
        {
            try
            {
                _albumGorselleriDal.Add(AlbumGorselleri);
                return new DataResult<AlbumGorselleri>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<AlbumGorselleri>(null, false, ex.Message);
            }
        }

        public IResult Delete(AlbumGorselleri AlbumGorselleri)
        {
            try
            {
                _albumGorselleriDal.Delete(AlbumGorselleri);
                return new DataResult<AlbumGorselleri>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<AlbumGorselleri>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<AlbumGorselleri>> GetAlbumGorselleriIDList(string id)
        {
            try
            {
                var data = _albumGorselleriDal.GetAlbumGorselleriIDList(id);

                SuccessDataResult<IList<AlbumGorselleri>> result = new SuccessDataResult<IList<AlbumGorselleri>>();
                return new DataResult<IList<AlbumGorselleri>>(data, true);



            }
            catch (Exception ex)
            {
                return new DataResult<IList<AlbumGorselleri>>(null, false, ex.Message);

            }
        }

        public IDataResult<AlbumGorselleri> GetById(int Id)
        {
            try
            {
                return new DataResult<AlbumGorselleri>(_albumGorselleriDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<AlbumGorselleri>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<AlbumGorselleri>> GetList()
        {
            try
            {

                SuccessDataResult<IList<AlbumGorselleri>> result = new SuccessDataResult<IList<AlbumGorselleri>>();
                return new DataResult<IList<AlbumGorselleri>>(_albumGorselleriDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<AlbumGorselleri>>(null, false, ex.Message);
            }

        }


        public IResult Update(AlbumGorselleri AlbumGorselleri)
        {
            try
            {
                _albumGorselleriDal.Update(AlbumGorselleri);
                SuccessDataResult<AlbumGorselleri> result = new SuccessDataResult<AlbumGorselleri>();
                return new DataResult<AlbumGorselleri>(AlbumGorselleri, true);
            }
            catch (Exception ex)
            {
                return new DataResult<AlbumGorselleri>(null, false, ex.Message);
            }

        }
    }
}
