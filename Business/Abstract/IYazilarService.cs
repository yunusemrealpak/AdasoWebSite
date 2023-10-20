using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IYazilarService
    {
        IResult Add(Yazilar Yazilar);

        IResult Delete(Yazilar Yazilar);

        IDataResult<Yazilar> GetById(int Id);

        IDataResult<IList<Yazilar>> GetList();

        IDataResult<IList<Yazilar>> GetListWithPaging(YazilarFilter filter);

        IDataResult<Yazilar> GetPopup();

        int GetListWithPagingCount(YazilarFilter filter);

        IDataResult<int> GetMaxId();

        IDataResult<IList<SliderUI>> Slider();
        IDataResult<IList<Yazilar>> Duyurular(/*SliderFilter SliderFilter*/);

        IDataResult<IList<DuyurularUI>> UstDuyurular();

        //IDataResult<IList<Yazilar>> GetListWithPagingView(int skip, int take, string baslik);
        IResult Update(Yazilar Yazilar);

    }
}

