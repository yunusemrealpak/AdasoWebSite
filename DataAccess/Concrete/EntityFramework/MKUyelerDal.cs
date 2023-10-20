using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMKUyelerDal : EfEntityRepositoryBase<MKUyeler, AdasoContext>, IMKUyelerDal
    {
        public IQueryable<MKUyeler> Filtrele(IQueryable<MKUyeler> query, MkUyelerFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.ara_ != "")
                {

                    query = from x in query where (x.Ad + " " + x.Soyad).Contains(filter.ara_) select x;

                }
                if (filter.MeslekKomitesiAsilUyesimi == true && filter.MeslekGrubuKodu == "0")
                {
                    query = query.Where(x => x.MeslekKomitesiAsilUyesimi == true && x.Etkin == true && x.MeslekKomitesiUyelikDustu == false);

                }
                else if (filter.MeslekKomitesiAsilUyesimi == true && filter.MeslekGrubuKodu != "0")
                {
                    query = query.Where(x => x.MeslekKomitesiAsilUyesimi == true && x.Etkin == true && x.MeslekKomitesiUyelikDustu == false && x.MeslekGrubuKodu == filter.MeslekGrubuKodu);
                }
                if (filter.YonetimKuruluAsilUyesimi == true)
                {
                    query = query.Where(x => x.YonetimKuruluAsilUyesimi == true && x.Etkin == true && x.YonetimKuruluUyelikDustu == false);

                }
                if (filter.MeclisAsilUyesimi == true)
                {
                    query = query.Where(x => x.MeclisAsilUyesimi == true && x.Etkin == true && x.MeclisUyelikDustu == false && x.MeclisSira != 0);

                }
            }

            return query;
        }
        public List<MKUyeler> GetListWithPaging(MkUyelerFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.MKUyeler.AsQueryable();
                filter.ara_ = string.IsNullOrEmpty(filter.ara_) ? "" : filter.ara_;

                result = Filtrele(result, filter);

                if (filter.MeslekKomitesiAsilUyesimi == true)
                    result = result.OrderBy(x => x.MeslekKomistesiSira);
                if (filter.YonetimKuruluAsilUyesimi == true)
                    result = result.OrderBy(x => x.YonetimKuruluSira);
                if (filter.MeclisAsilUyesimi == true)
                    result = result.OrderBy(x => x.MeclisSira);


                return result.Where(x => x.DonemID == 2).Skip(filter.Skip).Take(filter.Take).ToList();

            }
        }

        public int GetListWithPagingCount(MkUyelerFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.MKUyeler.AsQueryable();
                filter.ara_ = string.IsNullOrEmpty(filter.ara_) ? "" : filter.ara_;


                result = Filtrele(result, filter);
                return result.Where(x => x.DonemID == 2).Count();
            }
        }
    }
}

