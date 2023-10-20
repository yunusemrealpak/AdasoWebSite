using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.ViewComponents
{
    public class TebliglerTabViewComponent : ViewComponent
    {
        public IApiCall _apiCall;

        public TebliglerTabViewComponent(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            ResponseMessage<List<TebliglerUI>> GetListAnaSayfaTebliglerTab = _apiCall.Get<List<TebliglerUI>>("Tebligler", "GetListAnaSayfaTebliglerTab");

            return View(GetListAnaSayfaTebliglerTab);
        }
    }
}