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
    public class EfProjelerDal : EfEntityRepositoryBase<Projeler, AdasoContext>, IProjelerDal
    {
        public IQueryable<Projeler> Filtrele(IQueryable<Projeler> query, YazilarFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "baslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslik").SingleOrDefault();
                    query = query.Where(x => x.Baslik.Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "Durum") && filter.Filter.Any(x => x._value != "0"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "Durum").SingleOrDefault();
                    query = query.Where(x => x.Durum == Convert.ToInt32(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "baslangicTarihi"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslangicTarihi").FirstOrDefault()._value.Replace("00:00:00 GMT 0300 (GMT 03:00)", "").Trim().Substring(3);

                    var filterItem = Convert.ToDateTime(filtre).ToString("G");

                    query = query.Where(x => x.BaslangicTarihi == Convert.ToDateTime(filterItem));
                }
                if (filter.Filter.Any(x => x._field == "bitisTarihi"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "bitisTarihi").FirstOrDefault()._value.Replace("00:00:00 GMT 0300 (GMT 03:00)", "").Trim().Substring(3);
                    var filterItem = Convert.ToDateTime(filtre).ToString("G");
                    query = query.Where(x => x.BitisTarihi == Convert.ToDateTime(filterItem));
                }
            }

            return query;
        }

        public List<Projeler> GetListWithPaging(YazilarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Projeler.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;

                //return context.Projeler.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

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

                    else if (filter.Sort[0]._field == "bitisTarihi" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderBy(x => x.BitisTarihi).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "bitisTarihi" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.BitisTarihi).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "baslangicTarihi" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderBy(x => x.BaslangicTarihi).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "baslangicTarihi" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.BaslangicTarihi).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                }


                return result.Where(x => x.Baslik.Contains(filter.Baslik)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(YazilarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Projeler.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                return result.Where(x => x.Baslik.Contains(filter.Baslik)).Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Projeler.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}

