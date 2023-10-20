using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class AlbumlerManager : IAlbumlerService
    {
        private IAlbumlerDal _albumlerDal;

        public AlbumlerManager(IAlbumlerDal albumlerDal)
        {
            _albumlerDal = albumlerDal;
        }

        public IResult Add(Albumler Albumler)
        {
            try
            {
                _albumlerDal.Add(Albumler);
                return new DataResult<Albumler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Albumler>(null, false, ex.Message);
            }
        }

        public IResult Delete(Albumler Albumler)
        {
            try
            {
                _albumlerDal.Delete(Albumler);
                return new DataResult<Albumler>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Albumler>(null, false, ex.Message);
            }

        }

        public IDataResult<Albumler> GetById(int Id)
        {
            try
            {
                return new DataResult<Albumler>(_albumlerDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Albumler>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Albumler>> GetList()
        {
            try
            {

                SuccessDataResult<IList<Albumler>> result = new SuccessDataResult<IList<Albumler>>();
                return new DataResult<IList<Albumler>>(_albumlerDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Albumler>>(null, false, ex.Message);
            }

        }
        public IDataResult<Albumler> GetAlbumlerGUID(string id)
        {
            try
            {
                var data = _albumlerDal.GetAlbumlerGUID(id);

                SuccessDataResult<IList<Albumler>> result = new SuccessDataResult<IList<Albumler>>();
                return new DataResult<Albumler>(data, true);



            }
            catch (Exception ex)
            {
                return new DataResult<Albumler>(null, false, ex.Message);

            }
        }
        public IResult Update(Albumler Albumler)
        {
            try
            {
                _albumlerDal.Update(Albumler);
                SuccessDataResult<Albumler> result = new SuccessDataResult<Albumler>();
                return new DataResult<Albumler>(Albumler, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Albumler>(null, false, ex.Message);
            }

        }
    }
}
