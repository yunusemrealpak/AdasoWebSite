using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCrs_Sunumlar_SonucDal : EfEntityRepositoryBase<Crs_Sunumlar_Sonuc, AdasoContext>, ICrs_Sunumlar_SonucDal
    {
        public IQueryable<Crs_Sunumlar_Sonuc> Filtrele(IQueryable<Crs_Sunumlar_Sonuc> query, SunumlarFilter filter)
        {
            if (filter != null)
            {
                if (filter.anaBaslik != "")
                {
                    query = query.Where(x => x.AnaBaslik.Contains(filter.anaBaslik) || x.baslik.Contains(filter.Baslik));
                }

                if (filter.sunumMounth != 0)
                {
                    query = query.Where(x => x.SunumTarihi.Month == filter.sunumMounth);
                }
                if (filter.sunumYear != 0)
                {
                    query = query.Where(x => x.SunumTarihi.Year == filter.sunumYear);
                }
            }

            return query;
        }

        public List<Crs_Sunumlar_Sonuc> GetListWithFilter(SunumlarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Crs_Sunumlar_Sonuc.AsQueryable();

                if (filter.anaBaslik != "")
                    result = Filtrele(result, filter);
                if (filter.sunumMounth != 0)
                    result = Filtrele(result, filter);
                if (filter.sunumYear != 0)
                    result = Filtrele(result, filter);

                return result.OrderByDescending(x => x.SunumTarihi).ToList();

            }
        }

    }

}