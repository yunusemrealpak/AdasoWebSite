using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class viewUyeBilgileriController : ControllerBase
    {
        Iview_Uye_BilgileriService _view_Uye_BilgileriService;
        public viewUyeBilgileriController(Iview_Uye_BilgileriService view_Uye_BilgileriService)
        {
            _view_Uye_BilgileriService = view_Uye_BilgileriService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _view_Uye_BilgileriService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(firmalarFilter filter)
        {
            var result = _view_Uye_BilgileriService.GetListWithPaging(filter);
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }

        [HttpGet("GetByIdStr")]
        public IActionResult GetById(string ticaretsicilNo)
        {
            var result = _view_Uye_BilgileriService.GetByIdStr(ticaretsicilNo);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
