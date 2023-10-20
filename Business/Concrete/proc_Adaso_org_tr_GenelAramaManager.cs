using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace Business.Concrete
{
    public class proc_Adaso_org_tr_GenelAramaManager : Iproc_Adaso_org_tr_GenelAramaService
    {
        private Iproc_Adaso_org_tr_GenelAramaDal _proc_Adaso_org_tr_GenelAramaDal;

        public proc_Adaso_org_tr_GenelAramaManager(Iproc_Adaso_org_tr_GenelAramaDal proc_Adaso_org_tr_GenelAramaDal)
        {
            _proc_Adaso_org_tr_GenelAramaDal = proc_Adaso_org_tr_GenelAramaDal;
        }


        public IDataResult<IList<proc_Adaso_org_tr_GenelArama>> GetListWithPaging(SearchFilter filter)
        {

            List<proc_Adaso_org_tr_GenelArama> result = _proc_Adaso_org_tr_GenelAramaDal.GetListWithPaging(filter).ToList();

            return new SuccessDataResult<IList<proc_Adaso_org_tr_GenelArama>>(result) { DataCount = _proc_Adaso_org_tr_GenelAramaDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(SearchFilter filter)
        {
            return _proc_Adaso_org_tr_GenelAramaDal.GetListWithPagingCount(filter);
        }

    }
}