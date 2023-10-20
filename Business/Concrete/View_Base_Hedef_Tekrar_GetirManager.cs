using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Concrete
{
    public class View_Base_Hedef_Tekrar_GetirManager : IView_Base_Hedef_Tekrar_GetirService
    {
        private IView_Base_Hedef_Tekrar_GetirDal _View_Base_Hedef_Tekrar_GetirDal;

        public View_Base_Hedef_Tekrar_GetirManager(IView_Base_Hedef_Tekrar_GetirDal View_Base_Hedef_Tekrar_GetirDal)
        {
            _View_Base_Hedef_Tekrar_GetirDal = View_Base_Hedef_Tekrar_GetirDal;
        }

        public IDataResult<IList<View_Base_Hedef_Tekrar_Getir>> GetList()
        {
            try
            {

                FilterFullCalendar calendarfilter = new FilterFullCalendar();


                var data = _View_Base_Hedef_Tekrar_GetirDal.GetListFilter(calendarfilter);

                SuccessDataResult<IList<View_Base_Hedef_Tekrar_Getir>> result = new SuccessDataResult<IList<View_Base_Hedef_Tekrar_Getir>>();
                return new DataResult<IList<View_Base_Hedef_Tekrar_Getir>>(data, true);
            }
            catch (Exception ex)
            {
                return new DataResult<IList<View_Base_Hedef_Tekrar_Getir>>(null, false, ex.Message);
            }

        }

        public IDataResult<View_Base_Hedef_Tekrar_Getir> GetById(int Id)
        {
            try
            {
                return new DataResult<View_Base_Hedef_Tekrar_Getir>(_View_Base_Hedef_Tekrar_GetirDal.Get(x => x.ID == Id), true);
            }
            catch (Exception ex)
            {
                return new DataResult<View_Base_Hedef_Tekrar_Getir>(null, false, ex.Message);
            }

        }
    }
}