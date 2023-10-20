using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class mkUyelerViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public mkUyelerViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync(string mkUyeTipi)
        {
            PageItem item = new PageItem();
            if (mkUyeTipi == "MeslekKomiteleri")
                item.mkUyeTipi = "MeslekKomitesiAsilUyesimi=true";

            if (mkUyeTipi == "YonetimKurulu")
                item.mkUyeTipi = "YonetimKuruluAsilUyesimi=true";

            if (mkUyeTipi == "Meclis")
                item.mkUyeTipi = "MeclisAsilUyesimi=true";

            return View(item);
        }
    }
}
