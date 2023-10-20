using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnketlerController : ControllerBase
    {
        private IAnketlerService _anketlerService;

        public AnketlerController(IAnketlerService anketlerService)
        {
            _anketlerService = anketlerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _anketlerService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int anketlerId)
        {
            var result = _anketlerService.GetById(anketlerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Anketler anketler)
        {
            var result = _anketlerService.Add(anketler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Anketler anketler)
        {
            var result = _anketlerService.Update(anketler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Anketler anketler)
        {
            var result = _anketlerService.Delete(anketler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}