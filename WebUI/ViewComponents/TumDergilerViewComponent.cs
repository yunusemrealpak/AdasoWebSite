using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class TumDergilerViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public TumDergilerViewComponent(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
