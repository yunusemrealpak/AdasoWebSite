using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfGazetelerDal : EfEntityRepositoryBase<Gazeteler, AdasoContext>, IGazetelerDal
    {
        public List<Gazeteler> GetListHomePageMagazine()
        {
            using (var context = new AdasoContext())
            {
                var result = context.Gazeteler.Where(x => x.Etkin == true).OrderByDescending(s => s.ID).Take(4).ToList();

                return result;
            }
        }


        public IQueryable<Gazeteler> Filtrele(IQueryable<Gazeteler> query, GazetelerFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "sayi"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "sayi").SingleOrDefault();
                    query = query.Where(x => x.Sayi.ToString().Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "tarih"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "tarih").FirstOrDefault()._value.Replace("00:00:00 GMT 0300 (GMT 03:00)", "").Trim().Substring(3);
                    var filterItem = Convert.ToDateTime(filtre).ToString("G");
                    query = query.Where(x => x.Tarih == Convert.ToDateTime(filterItem));

                }



            }

            return query;
        }

        public List<Gazeteler> GetListWithPaging(GazetelerFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Gazeteler.AsQueryable();
                filter.sayi = string.IsNullOrEmpty(filter.sayi) ? "" : filter.sayi;

                result = Filtrele(result, filter);

                if (filter.Sort != null)
                {
                    if (filter.Sort[0]._field == "sayi" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Sayi.ToString().Contains(filter.sayi)).OrderBy(x => x.Sayi).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "sayi" && filter.Sort[0]._dir == "desc")
                    {

                        return result.Where(x => x.Sayi.ToString().Contains(filter.sayi)).OrderByDescending(x => x.Sayi).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                    else if (filter.Sort[0]._field == "tarih" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Sayi.ToString().Contains(filter.sayi)).OrderBy(x => x.Tarih).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "tarih" && filter.Sort[0]._dir == "desc")
                    {

                        return result.Where(x => x.Sayi.ToString().Contains(filter.sayi)).OrderByDescending(x => x.Tarih).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                }


                return result.Where(x => x.Sayi.ToString().Contains(filter.sayi)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(GazetelerFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Gazeteler.AsQueryable();
                filter.sayi = string.IsNullOrEmpty(filter.sayi) ? "" : filter.sayi;
                result = Filtrele(result, filter);
                return result.Where(x => x.Sayi.ToString().Contains(filter.sayi)).Count();
            }
        }


        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Gazeteler.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

