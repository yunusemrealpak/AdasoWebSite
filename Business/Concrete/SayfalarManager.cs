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
    public class SayfalarManager : ISayfalarService
    {
        private ISayfalarDal _sayfalarDal;

        public SayfalarManager(ISayfalarDal sayfalarDal)
        {
            _sayfalarDal = sayfalarDal;
        }

        public IResult Add(Sayfalar Sayfalar)
        {
            try
            {
                _sayfalarDal.Add(Sayfalar);
                return new DataResult<Sayfalar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sayfalar>(null, false, ex.Message);
            }
        }

        public IResult Delete(Sayfalar Sayfalar)
        {
            try
            {
                _sayfalarDal.Delete(Sayfalar);
                return new DataResult<Sayfalar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sayfalar>(null, false, ex.Message);
            }

        }

        public IDataResult<Sayfalar> GetById(int Id)
        {
            try
            {
                return new DataResult<Sayfalar>(_sayfalarDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sayfalar>(null, false, ex.Message);
            }

        }

        public IDataResult<Sayfalar> GetBySayfaURL(string sayfaURL)
        {
            try
            {
                return new DataResult<Sayfalar>(_sayfalarDal.Get(x => x.SayfaURL.Contains(sayfaURL)), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sayfalar>(null, false, ex.Message);
            }

        }
        public IDataResult<IList<Sayfalar>> GetList()
        {
            try
            {
                //SuccessDataResult<IList<Sayfalar>> result = new SuccessDataResult<IList<Sayfalar>>();

                return new DataResult<IList<Sayfalar>>(_sayfalarDal.GetList(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Sayfalar>>(null, false, ex.Message);
            }

        }
        public IDataResult<IList<view_Sayfalar>> GetListPageTitle()
        {
            try
            {
                //SuccessDataResult<IList<Sayfalar>> result = new SuccessDataResult<IList<Sayfalar>>();

                return new DataResult<IList<view_Sayfalar>>(_sayfalarDal.GetListPageTitle(), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<view_Sayfalar>>(null, false, ex.Message);
            }

        }
        public IResult Update(Sayfalar Sayfalar)
        {
            try
            {
                _sayfalarDal.Update(Sayfalar);
                SuccessDataResult<Sayfalar> result = new SuccessDataResult<Sayfalar>();
                return new DataResult<Sayfalar>(Sayfalar, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Sayfalar>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Sayfalar>> GetListWithPaging(SayfalarFilter filter)
        {
            List<Sayfalar> result = _sayfalarDal.GetListWithPaging(filter).ToList();
            result.ForEach(x =>
            {
                x.etkin_ = x.Etkin.ToString() == "True" ? "aktif" : "pasif";
            });
            result.ForEach(x =>
            {
                x.detailID = x.ID;
            });
            return new SuccessDataResult<IList<Sayfalar>>(result) { DataCount = _sayfalarDal.GetListWithPagingCount(filter) };
        }

        public int GetListWithPagingCount(SayfalarFilter filter)
        {
            return _sayfalarDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _sayfalarDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }

        public IDataResult<IList<view_Sayfalar>> GetByParentId(int parentId)
        {
            try
            {
                var data = _sayfalarDal.GetByParentId(parentId);
                return new SuccessDataResult<IList<view_Sayfalar>>(data) { DataCount = data.Count() };
            } catch (Exception ex)
            {
                return new DataResult<IList<view_Sayfalar>>(null, false, ex.Message);
            }
        }
    }
}
