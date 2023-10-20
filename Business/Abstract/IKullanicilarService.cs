using Core.Utilities.Results;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IKullanicilarService
    {
        IResult Add(Kullanicilar Kullanicilar);

        IResult Delete(Kullanicilar Kullanicilar);

        IDataResult<Kullanicilar> GetById(int Id);

        IDataResult<IList<Kullanicilar>> GetList();

        IResult Update(Kullanicilar Kullanicilar);

    }
}

