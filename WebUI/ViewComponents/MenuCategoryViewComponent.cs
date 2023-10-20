using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class MenuCategoryViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public MenuCategoryViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync(int menuId)
        {
            PageItem item = new PageItem();

            item.SayfalarTumliste = _apiCall.Get<List<Sayfalar>>("Sayfalar", $"getall");



            //List<string> MenuCategory_ = new List<string>();
            //var ensonkirilim = item.SayfalarTumliste.Data.Where(x => x.ID == menuId).FirstOrDefault();
            //var ensonkirilim1 = item.SayfalarTumliste.Data.Where(x => x.UstID == ensonkirilim.UstID).FirstOrDefault();
            item.listSayfalar = GetUstSayfa(menuId, item.SayfalarTumliste.Data);


            return View(item);
        }

        private List<Sayfalar> GetUstSayfa(int menuID, List<Sayfalar> lstSayfalar)
        {
            List<Sayfalar> result = new List<Sayfalar>();
            Sayfalar item = lstSayfalar.Where(x => x.ID == menuID).FirstOrDefault();
            result.Add(item);
            List<Sayfalar> lstGecici = lstSayfalar.Where(x => x.ID == item.UstID).ToList();
            if (lstSayfalar.Where(x => x.ID == item.UstID).Count() > 0)
            {
                result.AddRange(GetUstSayfa(item.UstID, lstSayfalar));
            }
            return result;
        }
    }
}
