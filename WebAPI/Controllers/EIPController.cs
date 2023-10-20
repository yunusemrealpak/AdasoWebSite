using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EIPController : ControllerBase
    {
        private IEIPService _eIPService;

        public EIPController(IEIPService eIPService)
        {
            _eIPService = eIPService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _eIPService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int eIPId)
        {
            var result = _eIPService.GetById(eIPId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(EIP eIP)
        {
            var result = _eIPService.Add(eIP);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(EIP eIP)
        {
            var result = _eIPService.Update(eIP);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(EIP eIP)
        {
            var result = _eIPService.Delete(eIP);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}