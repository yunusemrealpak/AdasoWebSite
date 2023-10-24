using Core.Utilities.Results;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface ITDHaberlerService
    {
        IResult Add(TDHaberler TDHaberler);

        IResult Delete(TDHaberler TDHaberler);

        IDataResult<TDHaberler> GetById(int Id);

        IDataResult<IList<TDHaberler>> GetList();

        Task<List<TDHaberler>> GetListAsync(int takeCount);

        IDataResult<IList<TDHaberler>> GetListWithPaging(YazilarFilter filter);

        int GetListWithPagingCount(YazilarFilter filter);

        IDataResult<int> GetMaxId();
        IResult Update(TDHaberler TDHaberler);

        IResult GetListHaberDto(int Id);
    }
}

