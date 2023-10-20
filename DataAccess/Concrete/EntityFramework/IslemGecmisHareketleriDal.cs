using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfIslemGecmisHareketleriDal : EfEntityRepositoryBase<IslemGecmisHareketleri, AdasoContext>, IIslemGecmisHareketleriDal
    {
        List<IslemGecmisHareketleri> IIslemGecmisHareketleriDal.GetTableList(int id)
        {
            using (var context = new AdasoContext())
            {
                var result = context.IslemGecmisHareketleri.Where(g => g.tableID == id).ToList();

                return result;
            }
        }
    }
}