using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class GazetelerViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public GazetelerViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PageItem Item = new PageItem();
            Item.GazetelerList = _apiCall.Get<List<Gazeteler>>("Gazeteler", "GetListHomePageMagazine");

            return View(Item);

        }
    }
}
