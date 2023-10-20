using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class UstDuyurularViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public UstDuyurularViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PageItem Item = new PageItem();

            Item.UstDuyurular = _apiCall.Get<List<DuyurularUI>>("Yazilar", "ustduyurular");



            return View(Item);
        }
    }
}