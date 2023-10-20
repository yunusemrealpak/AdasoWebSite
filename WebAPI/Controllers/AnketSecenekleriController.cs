using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnketSecenekleriController : ControllerBase
    {
        private IAnketSecenekleriService _anketSecenekleriService;

        public AnketSecenekleriController(IAnketSecenekleriService anketSecenekleriService)
        {
            _anketSecenekleriService = anketSecenekleriService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _anketSecenekleriService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int anketSecenekleriId)
        {
            var result = _anketSecenekleriService.GetById(anketSecenekleriId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(AnketSecenekleri anketSecenekleri)
        {
            var result = _anketSecenekleriService.Add(anketSecenekleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(AnketSecenekleri anketSecenekleri)
        {
            var result = _anketSecenekleriService.Update(anketSecenekleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AnketSecenekleri anketSecenekleri)
        {
            var result = _anketSecenekleriService.Delete(anketSecenekleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}