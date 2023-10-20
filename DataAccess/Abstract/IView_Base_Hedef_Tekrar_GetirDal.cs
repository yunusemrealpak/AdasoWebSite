using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IView_Base_Hedef_Tekrar_GetirDal : IEntityRepository<View_Base_Hedef_Tekrar_Getir>
    {

        List<View_Base_Hedef_Tekrar_Getir> GetListFilter(FilterFullCalendar filter);
    }
}
