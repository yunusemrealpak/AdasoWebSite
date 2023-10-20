using Core.DataAccess;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IAlbumlerDal : IEntityRepository<Albumler>
    {
        Albumler GetAlbumlerGUID(string id);
    }
}
