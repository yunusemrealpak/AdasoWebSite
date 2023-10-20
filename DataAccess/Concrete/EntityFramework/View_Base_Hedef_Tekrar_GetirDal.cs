using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfView_Base_Hedef_Tekrar_GetirDal : EfEntityRepositoryBase<View_Base_Hedef_Tekrar_Getir, AdasoContext>, IView_Base_Hedef_Tekrar_GetirDal
    {
        public List<View_Base_Hedef_Tekrar_Getir> GetListFilter(FilterFullCalendar filter)
        {
            using (var context = new AdasoContext())
            {
                
                var result = context.View_Base_Hedef_Tekrar_Getir.Where(x => x.hedefTekrarFaaliyetMi == filter.hedefTekrarFaaliyetMi).OrderByDescending(x => x.hedefTekrarFaaliyetBasTarih).ToList();
                //List<View_Base_Hedef_Tekrar_Getir> view_Base_Hedef_Tekrar_Getir = new List<View_Base_Hedef_Tekrar_Getir>();
                //return view_Base_Hedef_Tekrar_Getir;
                return result;

            }
        }
    }
}
