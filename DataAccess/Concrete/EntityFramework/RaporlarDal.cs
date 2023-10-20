using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRaporlarDal : EfEntityRepositoryBase<Raporlar, AdasoContext>, IRaporlarDal
    {

        public List<Raporlar> GetList()
        {
            using (var context = new AdasoContext())
            {
                var result = context.Raporlar.AsQueryable();

                return result.Where(x => x.Etkin == true).OrderByDescending(s => s.ID).Take(4).ToList();
            }
        }

        [LogAspect(typeof(DatabaseLogger))]
        
        public List<Raporlar> GetRaporTipList(RaporFilter filter)
        {
                using (var context = new AdasoContext())
                {
                    var result = context.Raporlar.AsQueryable();
                    return  result.Where(x => x.Etkin == filter.Etkin && x.Tip == filter.Tip).OrderByDescending(s => s.ID).Take(filter.Take).ToList();
                    
                }         
        }

        public IQueryable<Raporlar> Filtrele(IQueryable<Raporlar> query, RaporFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "baslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslik").SingleOrDefault();
                    query = query.Where(x => x.Baslik.Contains(filtre._value));
                }


            }

            return query;
        }

        public List<Raporlar> GetListWithPaging(RaporFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Raporlar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;

                //return context.Yazilar.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

                result = Filtrele(result, filter);

                if (filter.Sort != null)
                {
                    if (filter.Sort[0]._field == "baslik" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderBy(x => x.Baslik).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "baslik" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.Baslik).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                }
                if (filter.Tip == 0)
                {
                    return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();
                }

                return result.Where(x => x.Baslik.Contains(filter.Baslik) && x.Tip == filter.Tip).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(RaporFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Raporlar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                if (filter.Tip == 0)
                {
                    return result.Where(x => x.Baslik.Contains(filter.Baslik)).Count();
                }
                return result.Where(x => x.Baslik.Contains(filter.Baslik) && x.Tip == filter.Tip).Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Raporlar.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

