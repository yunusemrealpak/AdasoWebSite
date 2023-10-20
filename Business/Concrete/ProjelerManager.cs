using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos.Filter;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;


namespace Business.Concrete
{
    public class ProjelerManager : BaseManager<IProjelerDal, Projeler>, IProjelerService
    {
        private IProjelerDal _projelerDal;

        public ProjelerManager(IProjelerDal projelerDal) : base(projelerDal)
        {
            _projelerDal = projelerDal;
        }

        public IDataResult<IList<Projeler>> GetListWithPaging(YazilarFilter filter)
        {
            //int i = Convert.ToInt32("iso");
            //SuccessDataResult<IList<Yazilar>> result = new SuccessDataResult<IList<Yazilar>>();
            //return _yazilarDal.GetListWithPaging(skip, take, baslik).ToList();             

            List<Projeler> result = _projelerDal.GetListWithPaging(filter).ToList();
            //result.ForEach(x =>
            //{
            //    x.KategoriAdi = x.Grup == 1 ? "Haber" : "Duyuru";
            //});

            return new SuccessDataResult<IList<Projeler>>(result) { DataCount = _projelerDal.GetListWithPagingCount(filter) };

        }

        public int GetListWithPagingCount(YazilarFilter filter)
        {
            return _projelerDal.GetListWithPagingCount(filter);
        }
    }
}
