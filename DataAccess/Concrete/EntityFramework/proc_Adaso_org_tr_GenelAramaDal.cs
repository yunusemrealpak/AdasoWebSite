using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class Efproc_Adaso_org_tr_GenelAramaDal : EfEntityRepositoryBase<proc_Adaso_org_tr_GenelArama, AdasoContext>, Iproc_Adaso_org_tr_GenelAramaDal
    {

        public List<proc_Adaso_org_tr_GenelArama> GetListWithPaging(SearchFilter filter)
        {
            using (var context = new AdasoContext())
            {
                List<proc_Adaso_org_tr_GenelArama> result = context.proc_Adaso_org_tr_GenelArama.FromSql("exec dbo.proc_Adaso_org_tr_GenelArama 0,'" + filter.Filter[0]._value.ToLower() + "'," + filter.Skip + "," + filter.Take + "," + filter.PageSize).ToList();

                return result;

            }
        }

        public int GetListWithPagingCount(SearchFilter filter)
        {
            using (var context = new AdasoContext())
            {
                List<proc_Adaso_org_tr_GenelArama> result = context.proc_Adaso_org_tr_GenelArama.FromSql("exec dbo.proc_Adaso_org_tr_GenelArama 0,'" + filter.Filter[0]._value.ToLower() + "'," + filter.Skip + "," + filter.Take + "," + filter.PageSize).ToList();

                return result.Count();

            }
        }
    }
}