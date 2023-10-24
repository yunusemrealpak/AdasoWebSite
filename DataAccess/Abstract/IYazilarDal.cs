using Core.DataAccess;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DataAccess.Abstract
{
    public interface IYazilarDal : IEntityRepository<Yazilar>
    {
        List<SliderUI> Slider();
        List<Yazilar> Duyurular(/*SliderFilter filter*/);
        List<DuyurularUI> UstDuyurular();
        List<DuyurularUI> GetDuyurularWithSize(int max);
        List<Yazilar> GetListWithPaging(YazilarFilter filter);
        Yazilar GetPopup();
        int GetListWithPagingCount(YazilarFilter filter);
        new int GetMaxId();
    }
}