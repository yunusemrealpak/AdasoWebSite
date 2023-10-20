using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutsourceViewController : ControllerBase
    {
        IView_Base_OFirmalarService _view_Base_OFirmalarService;
        public OutsourceViewController(IView_Base_OFirmalarService view_Base_OFirmalarService)
        {
            _view_Base_OFirmalarService = view_Base_OFirmalarService;
        }

        [HttpGet("getall")]
        public IActionResult getall()
        {
            var result = _view_Base_OFirmalarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(firmalarFilter filter)
        {
            var result = _view_Base_OFirmalarService.GetListWithPaging(filter);
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
        public IActionResult GetById(string firmaTescilNo)
        {
            var result = _view_Base_OFirmalarService.GetByIdStr(firmaTescilNo);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}
