using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class TumHaberlerViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public TumHaberlerViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync(string yazitipi)
        {
            PageItem Item = new PageItem();
            Item.YaziTipi = yazitipi;

            return View(Item);
        }
    }
}
