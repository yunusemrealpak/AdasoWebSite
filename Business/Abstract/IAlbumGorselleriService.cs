using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IAlbumGorselleriService
    {
        IResult Add(AlbumGorselleri AlbumGorselleri);

        IResult Delete(AlbumGorselleri AlbumGorselleri);

        IDataResult<AlbumGorselleri> GetById(int Id);

        IDataResult<IList<AlbumGorselleri>> GetList();

        IDataResult<IList<AlbumGorselleri>> GetAlbumGorselleriIDList(string id);

        IResult Update(AlbumGorselleri AlbumGorselleri);

    }
}

