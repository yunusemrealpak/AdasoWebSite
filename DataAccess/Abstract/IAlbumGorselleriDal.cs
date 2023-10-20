using Core.DataAccess;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IAlbumGorselleriDal : IEntityRepository<AlbumGorselleri>
    {

        List<AlbumGorselleri> GetAlbumGorselleriIDList(string id);
    }
}
