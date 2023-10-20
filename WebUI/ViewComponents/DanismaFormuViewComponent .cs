using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class DanismaFormuViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public DanismaFormuViewComponent(IApiCall apiCall)
        {

            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PageItem item = new PageItem();
            return View(item);
        }
    }
}