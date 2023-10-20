using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class view_ortaklikController : ControllerBase
    {
        Iview_ortaklikService _view_ortaklikService;
        public view_ortaklikController(Iview_ortaklikService view_ortaklikService)
        {
            _view_ortaklikService = view_ortaklikService;
        }


        [HttpGet("GetByIdStr")]
        public IActionResult GetById(string uyeOID)
        {
            var result = _view_ortaklikService.GetByIdStr(uyeOID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetByListIdStr")]
        public IActionResult GetByListId(string uyeOID)
        {
            var result = _view_ortaklikService.GetList(uyeOID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
