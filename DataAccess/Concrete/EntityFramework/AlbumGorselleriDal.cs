using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAlbumGorselleriDal : EfEntityRepositoryBase<AlbumGorselleri, AdasoContext>, IAlbumGorselleriDal
    {
        public List<AlbumGorselleri> GetAlbumGorselleriIDList(string id)
        {
            using (var context = new AdasoContext())
            {
                var result = context.AlbumGorselleri.Where(g => g.AlbumGUID.ToString() == id).ToList();

                return result;
            }
        }
    }
}