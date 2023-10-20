using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Cache;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class MeclisViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public MeclisViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        private string webServiceUrl = "https://eoda.adaso.org.tr/AdasoWebMeclis?KullaniciAdi=Administrator&Sifre=**00**&bos=0";
        public async Task<IViewComponentResult> InvokeAsync(string mkUyeTipi)
        {
            PageItem item = new PageItem();
            string json = "";
            var policy = new RequestCachePolicy(RequestCacheLevel.BypassCache);

            using (WebClient wc = new WebClient())
            {
                wc.CachePolicy = policy;
                try
                {
                    json = wc.DownloadString(webServiceUrl);
                    item.organizations = JsonConvert.DeserializeObject<List<Organizasyon>>(json);
                }
                catch
                {
                    json = wc.DownloadString(webServiceUrl);
                    item.organizations = JsonConvert.DeserializeObject<List<Organizasyon>>(json);
                }
                return View(item);
            }
        }
    }
}
