using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class view_TemsilcilerController : ControllerBase
    {
        Iview_TemsilcilerService _view_TemsilcilerService;
        public view_TemsilcilerController(Iview_TemsilcilerService view_TemsilcilerService)
        {
            _view_TemsilcilerService = view_TemsilcilerService;
        }


        [HttpGet("GetByIdStr")]
        public IActionResult GetById(string uyeOID)
        {
            var result = _view_TemsilcilerService.GetByIdStr(uyeOID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetByListIdStr")]
        public IActionResult GetByListId(string uyeOID)
        {
            var result = _view_TemsilcilerService.GetByListId(uyeOID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
