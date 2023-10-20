using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfFireKararlariDal : EfEntityRepositoryBase<FireKararlari, AdasoContext>, IFireKararlariDal
    {
        public IQueryable<FireKararlari> Filtrele(IQueryable<FireKararlari> query, FireKararlariFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "Aciklama"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "Aciklama").SingleOrDefault();
                    query = query.Where(x => x.Aciklama.Contains(filtre._value));
                }

            }

            return query;
        }

        public List<FireKararlari> GetListWithPaging(FireKararlariFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.FireKararlari.AsQueryable();
                filter.Aciklama = string.IsNullOrEmpty(filter.Aciklama) ? "" : filter.Aciklama;

                //return context.FireKararlari.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

                result = Filtrele(result, filter);

                if (filter.Sort != null)
                {
                    if (filter.Sort[0]._field == "Aciklama" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Aciklama.Contains(filter.Aciklama)).OrderBy(x => x.Aciklama).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "Aciklama" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Aciklama.Contains(filter.Aciklama)).OrderByDescending(x => x.Aciklama).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                }

                return result.Where(x => x.Aciklama.Contains(filter.Aciklama)).OrderByDescending(x => x.Tarih).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(FireKararlariFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.FireKararlari.AsQueryable();
                filter.Aciklama = string.IsNullOrEmpty(filter.Aciklama) ? "" : filter.Aciklama;
                result = Filtrele(result, filter);
                return result.Where(x => x.Aciklama.Contains(filter.Aciklama)).Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.FireKararlari.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

