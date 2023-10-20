using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class YoutubeViewComponent : ViewComponent
    {
        public IApiCall _apiCall;

        public YoutubeViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            YoutubeFilter youtubeFilter = new YoutubeFilter();
            youtubeFilter.Baslik = "";
            youtubeFilter.Take = 3;
            youtubeFilter.Skip = 0;

            var result = _apiCall.Post<List<Youtube>>("Youtube", $"getallwithpaging", youtubeFilter);


            return View(result);
        }
    }
}
