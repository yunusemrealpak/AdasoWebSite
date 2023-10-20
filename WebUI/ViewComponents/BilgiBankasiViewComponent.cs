using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class BilgiBankasiViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public BilgiBankasiViewComponent(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PageItem item = new PageItem();
            item.SayfalarTumliste = _apiCall.Get<List<Sayfalar>>("Sayfalar", $"getall");
            return View(item);
        }
    }
}