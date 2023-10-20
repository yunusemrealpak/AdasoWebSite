using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class DuyurularViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public DuyurularViewComponent(ILogger<DuyurularViewComponent> logger, IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //ResponseMessage<List<Yazilar>> Duyurular = _apiCall.Get<List<Yazilar>>("Yazilar", "Duyurular");
            PageItem item = new PageItem();
            item.UstDuyurular = _apiCall.Get<List<DuyurularUI>>("Yazilar", "ustduyurular");

            return View(item);
        }
    }
}