using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace Business.Concrete
{
    public class YazilarManager : IYazilarService
    {
        private IYazilarDal _yazilarDal;

        public YazilarManager(IYazilarDal yazilarDal)
        {
            _yazilarDal = yazilarDal;
        }

        public IResult Add(Yazilar Yazilar)
        {
            try
            {
                _yazilarDal.Add(Yazilar);


                return new DataResult<Yazilar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Yazilar>(null, false, ex.Message);
            }
        }

        public IResult Delete(Yazilar Yazilar)
        {
            try
            {
                _yazilarDal.Delete(Yazilar);
                return new DataResult<Yazilar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Yazilar>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<DuyurularUI>> UstDuyurular()
        {
            try
            {
                var data = _yazilarDal.UstDuyurular();
                //data.ForEach(x =>
                //{
                //    x.KategoriAdi = x.Grup == 2 ? "Haber" : "Duyuru";
                //});

                SuccessDataResult<IList<DuyurularUI>> result = new SuccessDataResult<IList<DuyurularUI>>();
                return new DataResult<IList<DuyurularUI>>(data, true);


            }
            catch (Exception ex)
            {
                return new DataResult<IList<DuyurularUI>>(null, false, ex.Message);
            }
        }
        public IDataResult<IList<Yazilar>> Duyurular()
        {
            try
            {
                var data = _yazilarDal.Duyurular();
                //data.ForEach(x =>
                //{
                //    x.KategoriAdi = x.Grup == 2 ? "Haber" : "Duyuru";
                //});

                SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
                return new DataResult<IList<Yazilar>>(data, true);


            }
            catch (Exception ex)
            {
                return new DataResult<IList<Yazilar>>(null, false, ex.Message);
            }
        }

        public IDataResult<Yazilar> GetById(int Id)
        {
            try
            {
                return new DataResult<Yazilar>(_yazilarDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<Yazilar>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<Yazilar>> GetList()
        {
            try
            {
                var data = _yazilarDal.GetList().ToList();

                //data.ForEach(x =>
                //{
                //    x.KategoriAdi = x.Grup == 2 ? "Haber" : "Duyuru";
                //});

                SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
                return new DataResult<IList<Yazilar>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Yazilar>>(null, false, ex.Message);
            }

        }

        public IDataResult<Yazilar> GetPopup()
        {
            try
            {
                var data = _yazilarDal.GetPopup();

                SuccessDataResult<Yazilar> result = new SuccessDataResult<Yazilar>();

                return new DataResult<Yazilar>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Yazilar>(null, false, ex.Message);
            }

        }
        //[CacheAspect()]
        //[LogAspect(typeof(DatabaseLogger))]
        //[ExceptionLogAspect(typeof(DatabaseLogger))]
        public IDataResult<IList<Yazilar>> GetListWithPaging(YazilarFilter filter)
        {
            //int i = Convert.ToInt32("iso");
            //SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
            //return _yazilarDal.GetListWithPaging(skip, take, baslik).ToList();             

            List<Yazilar> result = _yazilarDal.GetListWithPaging(filter).ToList();
            result.ForEach(x =>
            {
                x.etkin_ = x.Etkin.ToString() == "True" ? "aktif" : "pasif";
            });

            return new SuccessDataResult<IList<Yazilar>>(result) { DataCount = _yazilarDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(YazilarFilter filter)
        {
            return _yazilarDal.GetListWithPagingCount(filter);
        }

        public IDataResult<int> GetMaxId()
        {
            var data = _yazilarDal.GetMaxId();
            SuccessDataResult<int> result = new SuccessDataResult<int>();
            return new DataResult<int>(data, true);
        }


        [CacheAspect(60)]
        public IDataResult<IList<SliderUI>> Slider()
        {
            try
            {
                //var data = _yazilarDal.GetList().Where(s=>s.Etkin==true && s.Grup==1 && s.ResimUrl!="").Take(10).OrderByDescending(o => o.Tip).OrderByDescending(o => o.BaslangicTarihi).ToList();
                var data = _yazilarDal.Slider();

                //data.ForEach(x =>
                //{
                //    x.KategoriAdi = x.Grup == 2 ? "Haber" : "Duyuru";
                //});

                //_cacheManager.RemoveByPattern("Business.Abstract.IYazilarService");
                SuccessDataResult<IList<SliderUI>> result = new SuccessDataResult<IList<SliderUI>>();
                return new DataResult<IList<SliderUI>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<SliderUI>>(null, false, ex.Message);
            }
        }

        //public IDataResult<IList<Yazilar>> GetListWithPagingView(int skip, int take, string baslik)
        //{
        //    try
        //    {
        //        SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
        //        return new SuccessDataResult<IList<Yazilar>>(_yazilarDal.GetListWithPagingView(skip, take, baslik).ToList()) { DataCount = _yazilarDal.GetListWithPagingCount(baslik) };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ErrorDataResult<IList<Yazilar>>(null, ex.Message);
        //    }

        //}
        public IResult Update(Yazilar Yazilar)
        {
            try
            {
                _yazilarDal.Update(Yazilar);
                if (Yazilar.Popup == true)
                {
                    string sp_Query = "exec sp_popup_update  " + Yazilar.ID + "," + Yazilar.Popup;
                    _yazilarDal.SP_Add(sp_Query);
                }

                //SuccessDataResult<Yazilar> result = new SuccessDataResult<Yazilar>();
                return new DataResult<Yazilar>(Yazilar, true);
            }
            catch (Exception ex)
            {
                return new DataResult<Yazilar>(null, false, ex.Message);
            }

        }
    }
}