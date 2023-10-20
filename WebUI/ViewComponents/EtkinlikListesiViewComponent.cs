using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class EtkinlikListesiViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public EtkinlikListesiViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            PageItem item = new PageItem();

            #region Get Çağrı
            FilterFullCalendar filter = new FilterFullCalendar();

            //ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>> View_Base_Hedef_Tekrar_Getir_List = _apiCall.Get<List<View_Base_Hedef_Tekrar_Getir>>("View_Base_Hedef_Tekrar_Getir", $"getall");
            ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>> View_Base_Hedef_Tekrar_Getir_List = new ResponseMessage<List<View_Base_Hedef_Tekrar_Getir>>();
            //ResponseMessage<List<Etkinlikler>> GetListHomePageEtkinlikler = _apiCall.Post<List<Etkinlikler>>("Etkinlikler", $"GetListHomePageActives", filter);

            if (View_Base_Hedef_Tekrar_Getir_List.Success)
                return View(View_Base_Hedef_Tekrar_Getir_List);


            return View(View_Base_Hedef_Tekrar_Getir_List);
            #endregion
        }
    }
}
