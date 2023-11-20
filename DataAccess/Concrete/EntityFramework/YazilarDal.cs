using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfYazilarDal : EfEntityRepositoryBase<Yazilar, AdasoContext>, IYazilarDal
    {
        public List<Yazilar> Duyurular()
        {
            using (var context = new AdasoContext())
            {
                var result = context.Yazilar.Where(x => x.Etkin == true && x.Grup == 2 && x.Tip == 1).OrderByDescending(s => s.BitisTarihi).Take(10).ToList();


                return result;

            }
        }

        public IQueryable<Yazilar> Filtrele(IQueryable<Yazilar> query, YazilarFilter filter)
        {


            if (filter.Filter != null)
            {
                if (filter.Filter.Any(x => x._field == "baslik"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "baslik").SingleOrDefault();
                    query = query.Where(x => x.Baslik.Contains(filtre._value));
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
                if (filter.Filter.Any(x => x._field == "kategoriAdi"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "kategoriAdi").SingleOrDefault();
                    query = query.Where(x => x.KategoriAdi.Contains(filtre._value));
                }
                if (filter.Filter.Any(x => x._field == "tip"))
                {
                    var filtre = filter.Filter.Where(x => x._field == "tip").SingleOrDefault();

                    _ = int.TryParse(filtre._value, out int tip);

                    query = query.Where(x => x.Tip == tip);
                }
            }
            return query;
        }

        public List<Yazilar> GetListWithPaging(YazilarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Yazilar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;

                //return context.Yazilar.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

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
                var result = context.Yazilar.AsQueryable();
                filter.Baslik = string.IsNullOrEmpty(filter.Baslik) ? "" : filter.Baslik;
                result = Filtrele(result, filter);
                return result.Where(x => x.Baslik.Contains(filter.Baslik)).Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.Yazilar.Select(s => s.ID).Max();
                return result;
            }
        }

        public List<SliderUI> Slider(/*SliderFilter filter*/)
        {
            using (var context = new AdasoContext())
            {
                var result = context.Sliders.ToList();
                //return context.Yazilar.Where(x => x.Baslik.Contains(baslik)).OrderByDescending(x => x.BitisTarihi).Skip(skip).Take(take).ToList();

                return result;

            }
        }

        public List<DuyurularUI> UstDuyurular()
        {
            using (var context = new AdasoContext())
            {
                var result = context.DuyurularUI.ToList();


                return result;

            }
        }
        public Yazilar GetPopup()
        {
            using (var context = new AdasoContext())
            {
                var result = context.Yazilar.AsQueryable();


                return result.Where(x => x.Grup == 2 && x.Etkin == true && x.KategoriAdi == "Duyurular" && x.Popup == true).FirstOrDefault();

            }
        }

        public List<DuyurularUI> GetDuyurularWithSize(int max)
        {
            using (var context = new AdasoContext())
            {
                return context.DuyurularUI.OrderBy(x => x.BaslangicTarihi).Take(max).ToList();
            }
        }

    }
}

