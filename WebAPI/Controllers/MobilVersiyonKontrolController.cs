using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilVersiyonKontrolController : ControllerBase
    {
        private IMobilVersiyonKontrolService _mobilVersiyonKontrolService;

        public MobilVersiyonKontrolController(IMobilVersiyonKontrolService mobilVersiyonKontrolService)
        {
            _mobilVersiyonKontrolService = mobilVersiyonKontrolService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _mobilVersiyonKontrolService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("checkVersion")]
        public IActionResult CheckVersion(VersionDto model)
        {
            var result = _mobilVersiyonKontrolService.CheckVersion(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]  
        public IActionResult GetById(int Id)
        {
            var result = _mobilVersiyonKontrolService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}