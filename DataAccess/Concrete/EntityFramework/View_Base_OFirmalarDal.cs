using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfView_Base_OFirmalarDal : EfEntityRepositoryBase<View_Base_OFirmalar, AdasoContext>, IView_Base_OFirmalarDal
    {
        public IQueryable<View_Base_OFirmalar> Filtrele(IQueryable<View_Base_OFirmalar> query, firmalarFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "unvan"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "unvan").SingleOrDefault();
                    query = query.Where(x => x.UNVAN.Contains(filtre._value));
                }


            }

            return query;
        }

        public List<View_Base_OFirmalar> GetListWithPaging(firmalarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.View_Base_OFirmalar.AsQueryable();
                filter.unvan = string.IsNullOrEmpty(filter.unvan) ? "" : filter.unvan;

                //return context.View_Base_OFirmalar.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

                result = Filtrele(result, filter);

                if (filter.Sort != null)
                {
                    if (filter.Sort[0]._field == "unvan" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.UNVAN.Contains(filter.unvan)).OrderBy(x => x.UNVAN).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "unvan" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.UNVAN.Contains(filter.unvan)).OrderByDescending(x => x.UNVAN).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }


                }

                return result.Where(x => x.UNVAN.Contains(filter.unvan)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(firmalarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.View_Base_OFirmalar.AsQueryable();
                filter.unvan = string.IsNullOrEmpty(filter.unvan) ? "" : filter.unvan;
                result = Filtrele(result, filter);
                return result.Where(x => x.UNVAN.Contains(filter.unvan)).Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.View_Base_OFirmalar.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

