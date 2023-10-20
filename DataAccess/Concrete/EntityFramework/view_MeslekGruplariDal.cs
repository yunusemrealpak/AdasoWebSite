using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dtos.Filter;
using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class Efview_MeslekGruplariDal : EfEntityRepositoryBase<view_MeslekGruplari, AdasoContext>, Iview_MeslekGruplariDal
    {
        public List<view_MeslekGruplari> GetListWithPaging(firmalarFilter filter)
        {
            throw new NotImplementedException();
        }

        public int GetListWithPagingCount(firmalarFilter filter)
        {
            throw new NotImplementedException();
        }
    }
}

