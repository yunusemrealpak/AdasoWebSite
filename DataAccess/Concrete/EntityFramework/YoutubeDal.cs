using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfYoutubeDal : EfEntityRepositoryBase<Youtube, AdasoContext>, IYoutubeDal
    {
        public IQueryable<Youtube> Filtrele(IQueryable<Youtube> query, YoutubeFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "baslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslik").SingleOrDefault();
                    query = query.Where(x => x.Baslik.Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "tarih"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "tarih").SingleOrDefault();
                    var filterItem = Convert.ToDateTime(filtre._value, CultureInfo.InvariantCulture);
                    query = query.Where(x => x.Tarih == filterItem);
                }

            }

            return query;
        }

        public List<Youtube> GetListWithPaging(YoutubeFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Youtube.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;

                //return context.Youtube.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

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

                    else if (filter.Sort[0]._field == "Tarih" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderBy(x => x.Tarih).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "Tarih" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.Tarih).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                }

                return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(YoutubeFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Youtube.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                return result.Where(x => x.Baslik.Contains(filter.Baslik)).Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Youtube.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}
