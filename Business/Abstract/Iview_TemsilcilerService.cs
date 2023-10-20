using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface Iview_TemsilcilerService
    {

        IDataResult<view_Temsilciler> GetByIdStr(string Id);
        IDataResult<IList<view_Temsilciler>> GetByListId(string Id);
    }
}

