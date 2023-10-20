using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface Iview_ortaklikService
    {

        IDataResult<view_ortaklik> GetByIdStr(string Id);
        IDataResult<IList<view_ortaklik>> GetList(string Id);
    }
}

