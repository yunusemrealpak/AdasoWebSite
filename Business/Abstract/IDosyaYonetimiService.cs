using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IDosyaYonetimiService
    {
        IDataResult<IList<DosyaYonetimi>> GetListWithPaging(DosyaYonetimiFilter filter);

        int GetListWithPagingCount(DosyaYonetimiFilter filter);

        IDataResult<int> GetMaxId();

        IDataResult<DosyaYonetimi> GetById(int Id);

        IResult DeleteById(int ID);

        IDataResult<IList<DosyaYonetimi>> GetList();

        IResult Add(DosyaYonetimi DosyaYonetimi);

        IResult Delete(DosyaYonetimi DosyaYonetimi);

        IResult Update(DosyaYonetimi DosyaYonetimi);

    }
}

