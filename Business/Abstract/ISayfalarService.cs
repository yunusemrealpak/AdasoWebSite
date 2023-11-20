using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface ISayfalarService
    {
        IResult Add(Sayfalar Sayfalar);

        IResult Delete(Sayfalar Sayfalar);

        IDataResult<Sayfalar> GetById(int Id);

        IDataResult<Sayfalar> GetBySayfaURL(string Baslik);

        IDataResult<IList<Sayfalar>> GetList();

        IDataResult<IList<Sayfalar>> GetListWithSubMenus();

        IDataResult<IList<view_Sayfalar>> GetListPageTitle();

        IResult Update(Sayfalar Sayfalar);

        IDataResult<IList<Sayfalar>> GetListWithPaging(SayfalarFilter filter);

        int GetListWithPagingCount(SayfalarFilter filter);

        IDataResult<int> GetMaxId();

        IDataResult<IList<view_Sayfalar>> GetByParentId(int parentId);


    }
}

