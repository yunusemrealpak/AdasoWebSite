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
    public class EfDosyaYonetimiDal : EfEntityRepositoryBase<DosyaYonetimi, AdasoContext>, IDosyaYonetimiDal
    {
        public IQueryable<DosyaYonetimi> Filtrele(IQueryable<DosyaYonetimi> query, DosyaYonetimiFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "FileName"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "FileName").SingleOrDefault();
                    query = query.Where(x => x.FileName.Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "CreateDate"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "CreateDate").SingleOrDefault();
                    var filterItem = Convert.ToDateTime(filtre._value, CultureInfo.InvariantCulture);
                    query = query.Where(x => x.CreateDate == filterItem);
                }

            }

            return query;
        }

        public List<DosyaYonetimi> GetListWithPaging(DosyaYonetimiFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.DosyaYonetimi.AsQueryable();
                filter.FileName = string.IsNullOrEmpty(filter.FileName) ? "" : filter.FileName;

                //return context.DosyaYonetimi.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

                result = Filtrele(result, filter);

                if (filter.Sort != null)
                {
                    if (filter.Sort[0]._field == "FileName" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.FileName.Contains(filter.FileName)).OrderBy(x => x.FileName).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "FileName" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.FileName.Contains(filter.FileName)).OrderByDescending(x => x.FileName).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                    else if (filter.Sort[0]._field == "Tarih" && filter.Sort[0]._dir == "asc")
                    {
                        return result.Where(x => x.FileName.Contains(filter.FileName)).OrderBy(x => x.CreateDate).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }
                    else if (filter.Sort[0]._field == "Tarih" && filter.Sort[0]._dir == "desc")
                    {
                        return result.Where(x => x.FileName.Contains(filter.FileName)).OrderByDescending(x => x.CreateDate).Skip(filter.Skip).Take(filter.Take == 0 ? 5 : filter.Take).ToList();
                    }

                }

                return result.Where(x => x.FileName.Contains(filter.FileName)).OrderByDescending(x => x.ID).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(DosyaYonetimiFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.DosyaYonetimi.AsQueryable();
                filter.FileName = string.IsNullOrEmpty(filter.FileName) ? "" : filter.FileName;
                result = Filtrele(result, filter);
                return result.Where(x => x.FileName.Contains(filter.FileName)).Count();
            }
        }


    }
}
