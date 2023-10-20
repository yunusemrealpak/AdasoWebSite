using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class Efview_ortaklikDal : EfEntityRepositoryBase<view_ortaklik, AdasoContext>, Iview_ortaklikDal
    {
        public List<view_ortaklik> GetListStrID(string ID)
        {

            using (var context = new AdasoContext())
            {
                var result = context.view_ortaklik;

                return result.Where(x => x.strID == ID).ToList();
            }

        }
    }
}

