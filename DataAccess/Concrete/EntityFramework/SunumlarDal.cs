using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSunumlarDal : EfEntityRepositoryBase<Sunumlar, AdasoContext>, ISunumlarDal
    {
        public IQueryable<Sunumlar> Filtrele(IQueryable<Sunumlar> query, SunumlarFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "baslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslik").SingleOrDefault();
                    query = query.Where(x => x.Baslik.Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "anaBaslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "anaBaslik").SingleOrDefault();
                    query = query.Where(x => x.AnaBaslik.Contains(filter.Filter[0]._value));
                }
                if (filter.Filter.Any(x => x._field == "hazirlayan"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "hazirlayan").SingleOrDefault();
                    query = query.Where(x => x.Hazirlayan.Contains(filtre._value));
                }
            }

            return query;
        }

        public List<Sunumlar> GetListWithPaging(SunumlarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Sunumlar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;

                //return context.Sunumlar.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

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
                    if (filter.Sort[0]._field == "anaBaslik" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.AnaBaslik.Contains(filter.anaBaslik)).OrderBy(x => x.AnaBaslik).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "anaBaslik" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.AnaBaslik.Contains(filter.anaBaslik)).OrderByDescending(x => x.AnaBaslik).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    if (filter.Sort[0]._field == "hazirlayan" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Hazirlayan.Contains(filter.Baslik)).OrderBy(x => x.Hazirlayan).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "hazirlayan" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Hazirlayan.Contains(filter.Baslik)).OrderByDescending(x => x.Hazirlayan).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                }

                return result.OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(SunumlarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Sunumlar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                return result.Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Sunumlar.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}