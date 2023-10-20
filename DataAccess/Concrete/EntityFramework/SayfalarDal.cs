using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSayfalarDal : EfEntityRepositoryBase<Sayfalar, AdasoContext>, ISayfalarDal
    {
        public IQueryable<Sayfalar> Filtrele(IQueryable<Sayfalar> query, SayfalarFilter filter)
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

        public List<Sayfalar> GetListWithPaging(SayfalarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Sayfalar.AsQueryable();
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
                }
                if (filter.ust_ == 0 && filter.ust == 1)
                {
                    return result.Where(x => x.Baslik.Contains(filter.Baslik) && (x.UstID == filter.ust || x.UstID == filter.ust_)).OrderBy(x => x.SiraNo).Skip(filter.Skip).Take(filter.Take).ToList();
                }
                else
                {
                    return result.Where(x => x.Baslik.Contains(filter.Baslik) && x.UstID == filter.ustx).OrderBy(x => x.SiraNo).Skip(filter.Skip).Take(filter.Take).ToList();

                }

            }
        }

        public List<view_Sayfalar> GetListPageTitle()
        {
            using (var context = new AdasoContext())
            {
                var result = context.view_Sayfalar.AsQueryable();

                return result.OrderBy(x => x.SiraNo).ToList();

            }
        }
        public int GetListWithPagingCount(SayfalarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Sayfalar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                if (filter.ust_ == 0 && filter.ust == 1)
                {
                    return result.Where(x => x.Baslik.Contains(filter.Baslik) && (x.UstID == filter.ust || x.UstID == filter.ust_)).OrderBy(x => x.SiraNo).Skip(filter.Skip).Take(filter.Take).Count();
                }
                else
                {
                    return result.Where(x => x.Baslik.Contains(filter.Baslik) && x.UstID == filter.ustx).OrderBy(x => x.SiraNo).Skip(filter.Skip).Take(filter.Take).Count();

                }
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Sayfalar.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

