using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface Iview_UyeUyelikSabitTelefonService
    {

        IDataResult<view_UyeUyelikSabitTelefon> GetByIdStr(string Id);
        IDataResult<IList<view_UyeUyelikSabitTelefon>> GetByListId(string Id);
    }
}

