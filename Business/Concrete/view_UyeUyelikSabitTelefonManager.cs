using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class view_UyeUyelikSabitTelefonManager : Iview_UyeUyelikSabitTelefonService
    {
        private Iview_UyeUyelikSabitTelefonDal _view_UyeUyelikSabitTelefonDal;

        public view_UyeUyelikSabitTelefonManager(Iview_UyeUyelikSabitTelefonDal view_UyeUyelikSabitTelefonDal)
        {
            _view_UyeUyelikSabitTelefonDal = view_UyeUyelikSabitTelefonDal;
        }

        public IDataResult<view_UyeUyelikSabitTelefon> GetByIdStr(string Id)
        {
            try
            {
                return new DataResult<view_UyeUyelikSabitTelefon>(_view_UyeUyelikSabitTelefonDal.GetByIdStr(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<view_UyeUyelikSabitTelefon>(null, false, ex.Message);
            }

        }

        public IDataResult<IList<view_UyeUyelikSabitTelefon>> GetByListId(string Id)
        {
            try
            {
                SuccessDataResult<IList<view_UyeUyelikSabitTelefon>> result = new SuccessDataResult<IList<view_UyeUyelikSabitTelefon>>();
                return new DataResult<IList<view_UyeUyelikSabitTelefon>>(_view_UyeUyelikSabitTelefonDal.GetListStrId(Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<view_UyeUyelikSabitTelefon>>(null, false, ex.Message);
            }
        }
    }
}
