using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class Efview_Uye_BilgileriDal : EfEntityRepositoryBase<view_Uye_Bilgileri, AdasoContext>, Iview_Uye_BilgileriDal
    {
        public IQueryable<view_Uye_Bilgileri> Filtrele(IQueryable<view_Uye_Bilgileri> query, firmalarFilter filter)
        {
            if (filter.Filter != null)
            {
                if (filter.DOGRULAMA == "true")
                {
                    query = query.Where(x => x.VERGI_NO.Contains(filter.VERGI_NO));
                    return query;
                }

                if (filter.unvan != "")
                {
                    query = query.Where(x => x.UNVAN.Contains(filter.unvan) || x.strID.Contains(filter.unvan) || x.VERGI_NO.Contains(filter.unvan));
                }
                if (filter.MESLEK_GRUBU_NO != "0")
                {
                    query = query.Where(x => x.MESLEK_GRUBU_NO == filter.MESLEK_GRUBU_NO);
                }
                if (filter.UYELIK_DURUM != "0")
                {
                    query = query.Where(x => x.UYELIK_DURUM == filter.UYELIK_DURUM);
                }
            }
            return query;
        }

        public List<view_Uye_Bilgileri> GetListWithPaging(firmalarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.view_Uye_Bilgileri.AsQueryable();
                filter.unvan = string.IsNullOrEmpty(filter.unvan) ? "" : filter.unvan;
                filter.MESLEK_GRUBU_NO = string.IsNullOrEmpty(filter.MESLEK_GRUBU_NO) ? "" : filter.MESLEK_GRUBU_NO;

                result = Filtrele(result, filter);
                try
                {
                    if (filter.VERGI_NO != "00" && filter.VERGI_NO.Split('|')[1] == "TNBKep")
                    {
                        return result.Where(v => v.VERGI_NO == filter.VERGI_NO.Split('|')[0]).ToList();
                    }
                }
                catch { }

                return result.OrderBy(x => x.UNVAN).Skip(filter.Skip).Take(filter.Take).ToList();
            }
        }

        public int GetListWithPagingCount(firmalarFilter filter)
        {
            using (var context = new AdasoContext())
            {
                var result = context.view_Uye_Bilgileri.AsQueryable();
                filter.unvan = string.IsNullOrEmpty(filter.unvan) ? "" : filter.unvan;
                filter.MESLEK_GRUBU_NO = string.IsNullOrEmpty(filter.MESLEK_GRUBU_NO) ? "" : filter.MESLEK_GRUBU_NO;
                result = Filtrele(result, filter);
                return result.Count();
            }
        }

        public new int GetMaxId()
        {
            using (var context = new AdasoContext())
            {
                int result = context.view_Uye_Bilgileri.Select(s => s.ID).Max();
                return result;
            }
        }
    }
}