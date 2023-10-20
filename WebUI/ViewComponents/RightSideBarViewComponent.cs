using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class RightSideBarViewComponent : ViewComponent
    {
        public IApiCall _apiCall;

        public RightSideBarViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync(int YazilarGrup, int UstID, int SayfaID)
        {
            PageItem item = new PageItem();

            YoutubeFilter youtubeFilter = new YoutubeFilter();
            youtubeFilter.Baslik = "";
            youtubeFilter.Take = 3;
            youtubeFilter.Skip = 0;

            item.YoutubeList = _apiCall.Post<List<Youtube>>("Youtube", $"getallwithpaging", youtubeFilter);

            item.GetListPageTitle = _apiCall.Get<List<view_Sayfalar>>("Sayfalar", $"getlistpagetitle");

            item.YaziTipi = YazilarGrup == 1 ? "Haberler" : YazilarGrup == 2 ? "Duyurular" : YazilarGrup == 3 ? "Başkanın Mesajı" : YazilarGrup == 4 ? "İleti" : item.YaziTipi;
            item.UstIdSec = UstID;
            item.SayfaIdSec = SayfaID;

            return View(item);

        }
    }
}