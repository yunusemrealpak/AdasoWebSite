using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IView_Base_Hedef_Tekrar_GetirService
    {
        IDataResult<IList<View_Base_Hedef_Tekrar_Getir>> GetList();

        IDataResult<View_Base_Hedef_Tekrar_Getir> GetById(int Id);
    }
}

