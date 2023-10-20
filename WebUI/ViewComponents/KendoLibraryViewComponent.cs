using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebUI.ViewComponents
{
    public class KendoLibraryViewComponent : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {



            return View();
        }
    }
}
