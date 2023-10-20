using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class viewMeslekGruplariController : ControllerBase
    {
        Iview_MeslekGruplariService _view_MeslekGruplariService;
        public viewMeslekGruplariController(Iview_MeslekGruplariService view_MeslekGruplariService)
        {
            _view_MeslekGruplariService = view_MeslekGruplariService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _view_MeslekGruplariService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(firmalarFilter filter)
        {
            var result = _view_MeslekGruplariService.GetListWithPaging(filter);
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
        public IActionResult GetById(string TICARET_SICIL_NO)
        {
            var result = _view_MeslekGruplariService.GetByIdStr(TICARET_SICIL_NO);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
