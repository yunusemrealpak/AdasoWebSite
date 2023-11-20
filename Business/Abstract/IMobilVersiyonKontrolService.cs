using Core.Utilities.Results;
using Entities.Dtos;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Business.Abstract
{
    public interface IMobilVersiyonKontrolService
    {   
        IDataResult<MobilVersiyonKontrol> GetById(int Id);
        IDataResult<MobilVersiyonKontrol> CheckVersion(VersionDto model);
        IDataResult<IList<MobilVersiyonKontrol>> GetList();
        
     

    }
}