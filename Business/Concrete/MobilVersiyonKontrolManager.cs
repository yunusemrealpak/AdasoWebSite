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
    public class MobilVersiyonKontrolManager : IMobilVersiyonKontrolService
    {
        private IMobilVersiyonKontrolDal _mobilVersiyonKontrolDal;


        public MobilVersiyonKontrolManager(IMobilVersiyonKontrolDal MobilVersiyonKontrolDal)
        {
            _mobilVersiyonKontrolDal = MobilVersiyonKontrolDal;
        }
        public IDataResult<MobilVersiyonKontrol> CheckVersion(VersionDto model)
        {
            try
            {
                var versionControl = new DataResult<MobilVersiyonKontrol>(_mobilVersiyonKontrolDal.Get(x => x.os == model.os), true);
                
                if (Convert.ToInt16(model.version.Replace(".", ""))< Convert.ToInt16(versionControl.Data.version.Replace(".", "")))

                    return new DataResult<MobilVersiyonKontrol>(_mobilVersiyonKontrolDal.Get(x => x.os == model.os), false,"Uygulama güncel değil!");
                else
                    
                    return new DataResult<MobilVersiyonKontrol>(null, true, "Uygulama güncel.");
                
            }
            catch (Exception ex)
            {
                return new DataResult<MobilVersiyonKontrol>(null, false, ex.Message);
            }
        }

        public IDataResult<MobilVersiyonKontrol> GetById(int Id)
        {
            try
            {
                return new DataResult<MobilVersiyonKontrol>(_mobilVersiyonKontrolDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<MobilVersiyonKontrol>(null, false, ex.Message);
            }
        }

        public IDataResult<IList<MobilVersiyonKontrol>> GetList()
        {
            try
            {
                var data = _mobilVersiyonKontrolDal.GetList().ToList();
                SuccessDataResult<IList<MobilVersiyonKontrol>> result = new SuccessDataResult<IList<MobilVersiyonKontrol>>();
                return new DataResult<IList<MobilVersiyonKontrol>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<MobilVersiyonKontrol>>(null, false, ex.Message);
            }

        }
    }
}