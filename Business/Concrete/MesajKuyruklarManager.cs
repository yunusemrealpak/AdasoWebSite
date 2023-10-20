using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using WebApplication1.Models;

namespace Business.Concrete
{
    public class MesajKuyruklarManager : IMesajKuyruklarService
    {
        private IMesajKuyruklarDal _MesajKuyruklarDal;

        public MesajKuyruklarManager(IMesajKuyruklarDal MesajKuyruklarDal)
        {
            _MesajKuyruklarDal = MesajKuyruklarDal;
        }

        public IResult Add(MesajKuyruklar MesajKuyruklar)
        {
            try
            {

                string emailBody = "<h2>" + MesajKuyruklar.mesajKuyrukBaslik + "</h2>" +
                                    "<p> " + MesajKuyruklar.mesajKuyrukIcerik + "</p>" +
                                    "<p>" + DateTime.Now.ToString("F") + "</p>";

                string sp_Query = "exec MesajKuyrukDB.dbo.Proc_MesajKuyruk_Ekle 'AdasoWeb','Mail','AdasoIletisim','Yazý','Ýþleri','" + MesajKuyruklar.PersonelEmail + "','" + MesajKuyruklar.baslik + "','" + emailBody + "','" + DateTime.Now.ToLongTimeString() + "','" + DateTime.Now.ToLongTimeString() + "',0";
                _MesajKuyruklarDal.SP_Add(sp_Query);


                return new DataResult<MesajKuyruklar>(null, true);
            }
            catch (Exception ex)
            {
                return new DataResult<MesajKuyruklar>(null, false, ex.Message);
            }
        }
    }
}