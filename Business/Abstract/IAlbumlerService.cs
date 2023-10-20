using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IAlbumlerService
    {
        IResult Add(Albumler Albumler);

        IResult Delete(Albumler Albumler);

        IDataResult<Albumler> GetById(int Id);

        IDataResult<IList<Albumler>> GetList();
        IDataResult<Albumler> GetAlbumlerGUID(string id);
        IResult Update(Albumler Albumler);

    }
}

