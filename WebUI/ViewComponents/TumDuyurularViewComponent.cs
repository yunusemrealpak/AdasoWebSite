using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class TumDuyurularViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public TumDuyurularViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
