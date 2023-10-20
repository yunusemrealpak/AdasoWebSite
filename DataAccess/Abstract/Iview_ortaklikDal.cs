using Core.DataAccess;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface Iview_ortaklikDal : IEntityRepository<view_ortaklik>
    {
        List<view_ortaklik> GetListStrID(string ID);
    }
}
