using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class RaporlarViewComponent : ViewComponent
    {
        public IApiCall _apiCall;
        public RaporlarViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync(int Tip)
        {
            RaporFilter raporlarFilter = new RaporFilter();
            raporlarFilter.Baslik = "";
            raporlarFilter.Take = 100;
            raporlarFilter.Skip = 0;
            raporlarFilter.Tip = 0;
            //raporlarFilter.Tip = Tip;
            var result = _apiCall.Post<List<Raporlar>>("Raporlar", $"getallwithpaging", raporlarFilter);


            return View(result);
        }
    }
}
