using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Crs_Sunumlar_SonucController : ControllerBase
    {
        private ICrs_Sunumlar_SonucService _Crs_Sunumlar_SonucService;



        public Crs_Sunumlar_SonucController(ICrs_Sunumlar_SonucService Crs_Sunumlar_SonucService)
        {
            _Crs_Sunumlar_SonucService = Crs_Sunumlar_SonucService;
        }

        [HttpPost("getall")]
        public IActionResult GetList()
        {
            var result = _Crs_Sunumlar_SonucService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("getallwithfilter")]
        public IActionResult GetListWithPaging(SunumlarFilter filter)
        {
            var result = _Crs_Sunumlar_SonucService.GetListWithFilter(filter);
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }
    }
}