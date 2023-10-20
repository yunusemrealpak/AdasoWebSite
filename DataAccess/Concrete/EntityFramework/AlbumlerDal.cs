using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAlbumlerDal : EfEntityRepositoryBase<Albumler, AdasoContext>, IAlbumlerDal
    {
        public Albumler GetAlbumlerGUID(string id)
        {

            using (var context = new AdasoContext())
            {
                var result = context.Albumler.Where(g => g.GUID.ToString() == id).FirstOrDefault();

                return result;
            }
        }
    }
}

