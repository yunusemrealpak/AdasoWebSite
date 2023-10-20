using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class view_UyeUyelikSabitTelefonController : ControllerBase
    {
        Iview_UyeUyelikSabitTelefonService _view_UyeUyelikSabitTelefonService;
        public view_UyeUyelikSabitTelefonController(Iview_UyeUyelikSabitTelefonService view_UyeUyelikSabitTelefonService)
        {
            _view_UyeUyelikSabitTelefonService = view_UyeUyelikSabitTelefonService;
        }


        [HttpGet("GetByIdStr")]
        public IActionResult GetById(string uyeOID)
        {
            var result = _view_UyeUyelikSabitTelefonService.GetByIdStr(uyeOID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetByListIdStr")]
        public IActionResult GetByListId(string uyeOID)
        {
            var result = _view_UyeUyelikSabitTelefonService.GetByListId(uyeOID);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
