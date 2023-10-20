using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class TumRaporlarViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public TumRaporlarViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync(int raporTipi)
        {
            PageItem item = new PageItem();
            item.RaporTipSec = raporTipi;

            return View(item);
        }
    }
}
