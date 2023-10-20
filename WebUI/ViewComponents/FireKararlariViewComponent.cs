using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class FireKararlariViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public FireKararlariViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FireKararlariFilter FireKararlariFilter = new FireKararlariFilter();
            FireKararlariFilter.Aciklama = "";
            FireKararlariFilter.Take = 10;
            FireKararlariFilter.Skip = 0;

            var result = _apiCall.Post<List<FireKararlari>>("FireKararlari", $"getallwithpaging", FireKararlariFilter);


            return View(result);
        }
    }
}
