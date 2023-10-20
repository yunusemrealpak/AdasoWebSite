using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunumlarController : ControllerBase
    {
        private ISunumlarService _SunumlarService;



        public SunumlarController(ISunumlarService SunumlarService)
        {
            _SunumlarService = SunumlarService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _SunumlarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(SunumlarFilter filter)
        {
            var result = _SunumlarService.GetListWithPaging(filter);
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int SunumlarId)
        {
            var result = _SunumlarService.GetById(SunumlarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _SunumlarService.GetMaxId();


            return Ok(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Sunumlar Sunumlar)
        {
            var result = _SunumlarService.Add(Sunumlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Sunumlar Sunumlar)
        {
            var result = _SunumlarService.Update(Sunumlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Sunumlar Sunumlar)
        {
            var result = _SunumlarService.Delete(Sunumlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}