using Core.DataAccess;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IIslemGecmisHareketleriDal : IEntityRepository<IslemGecmisHareketleri>
    {
        List<IslemGecmisHareketleri> GetTableList(int id);
    }
}
