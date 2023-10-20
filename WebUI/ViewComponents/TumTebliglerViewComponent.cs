using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class TumTebliglerViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public TumTebliglerViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {


            return View();
        }
    }
}
