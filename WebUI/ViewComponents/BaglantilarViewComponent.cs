using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class BaglantilarViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public BaglantilarViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var result = _apiCall.Get<List<Baglantilar>>("Baglantilar", $"getall");

            if (result.Success)
            {
                return View(result);
            }

            else
            {
                return View();
            }
        }
    }
}
