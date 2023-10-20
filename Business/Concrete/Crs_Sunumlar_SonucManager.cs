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

    public class Crs_Sunumlar_SonucManager : ICrs_Sunumlar_SonucService
    {
        private ICrs_Sunumlar_SonucDal _SunumlarDal;
        public Crs_Sunumlar_SonucManager(ICrs_Sunumlar_SonucDal SunumlarDal)
        {
            _SunumlarDal = SunumlarDal;
        }
        public IDataResult<IList<Crs_Sunumlar_Sonuc>> GetList()
        {
            try
            {
                var data = _SunumlarDal.GetList().ToList();

                SuccessDataResult<IList<Crs_Sunumlar_Sonuc>> result = new SuccessDataResult<IList<Crs_Sunumlar_Sonuc>>();
                return new DataResult<IList<Crs_Sunumlar_Sonuc>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<Crs_Sunumlar_Sonuc>>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<Crs_Sunumlar_Sonuc>> GetListWithFilter(SunumlarFilter filter)
        {

            List<Crs_Sunumlar_Sonuc> result = _SunumlarDal.GetListWithFilter(filter).ToList();

            return new SuccessDataResult<IList<Crs_Sunumlar_Sonuc>>(result) { DataCount = 0 };

        }

    }
}