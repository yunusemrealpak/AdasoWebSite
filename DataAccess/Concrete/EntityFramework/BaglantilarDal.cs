using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBaglantilarDal : EfEntityRepositoryBase<Baglantilar, AdasoContext>, IBaglantilarDal
    {
        public IQueryable<Baglantilar> Filtrele(IQueryable<Baglantilar> query, BaglantilarFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "baslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslik").SingleOrDefault();
                    query = query.Where(x => x.Baslik.Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "grup"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "grup").SingleOrDefault();
                    query = query.Where(x => x.Grup.Contains(filtre._value));
                }
            }

            return query;
        }
        public List<Baglantilar> GetListWithPaging(BaglantilarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Baglantilar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;

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
                    if (filter.Sort[0]._field == "grup" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Grup)).OrderBy(x => x.Baslik).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "grup" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Grup.Contains(filter.Grup)).OrderByDescending(x => x.Grup).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                }
                return result.Where(x => x.Baslik.Contains(filter.Baslik) || x.Grup.Contains(filter.Grup)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }
        public int GetListWithPagingCount(BaglantilarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Baglantilar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                return result.Where(x => x.Baslik.Contains(filter.Baslik) || x.Grup.Contains(filter.Grup)).Count();
            }
        }
        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Baglantilar.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

