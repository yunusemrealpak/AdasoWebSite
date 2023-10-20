using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaglantilarController : ControllerBase
    {
        private IBaglantilarService _baglantilarService;
        public BaglantilarController(IBaglantilarService baglantilarService)
        {
            _baglantilarService = baglantilarService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _baglantilarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int baglantilarId)
        {
            var result = _baglantilarService.GetById(baglantilarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Baglantilar baglantilar)
        {
            var result = _baglantilarService.Add(baglantilar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Baglantilar baglantilar)
        {
            var result = _baglantilarService.Update(baglantilar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Baglantilar baglantilar)
        {
            var result = _baglantilarService.Delete(baglantilar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(BaglantilarFilter filter)
        {
            var result = _baglantilarService.GetListWithPaging(filter);
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _baglantilarService.GetMaxId();
            return Ok(result);

        }
    }
}