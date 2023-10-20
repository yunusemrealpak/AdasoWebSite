using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IIslemGecmisHareketleriService
    {
        IResult Add(IslemGecmisHareketleri IslemGecmisHareketleri);

        IResult Delete(IslemGecmisHareketleri IslemGecmisHareketleri);

        IDataResult<IslemGecmisHareketleri> GetById(int Id);

        IDataResult<IList<IslemGecmisHareketleri>> GetTableList(int id);

        IDataResult<IList<IslemGecmisHareketleri>> GetList();

        IResult Update(IslemGecmisHareketleri IslemGecmisHareketleri);

    }
}

