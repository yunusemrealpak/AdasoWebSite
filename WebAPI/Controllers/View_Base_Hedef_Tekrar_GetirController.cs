using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class View_Base_Hedef_Tekrar_GetirController : ControllerBase
    {
        private IView_Base_Hedef_Tekrar_GetirService _View_Base_Hedef_Tekrar_GetirService;
        public View_Base_Hedef_Tekrar_GetirController(IView_Base_Hedef_Tekrar_GetirService View_Base_Hedef_Tekrar_GetirService)
        {
            _View_Base_Hedef_Tekrar_GetirService = View_Base_Hedef_Tekrar_GetirService;
        }
        [HttpGet("getall")]
        [CacheAspect]
        public IActionResult GetList()
        {
            var result = _View_Base_Hedef_Tekrar_GetirService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int hedefTekrarId)
        {
            var result = _View_Base_Hedef_Tekrar_GetirService.GetById(hedefTekrarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}