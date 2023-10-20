using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class UyelerVNSearchViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public UyelerVNSearchViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }
    }
}
