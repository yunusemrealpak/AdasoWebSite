﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using WebApplication1.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfMobilVersiyonKontrolDal : EfEntityRepositoryBase<MobilVersiyonKontrol, AdasoContext>, IMobilVersiyonKontrolDal
    {
   
    }
}