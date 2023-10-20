using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosyaYonetimiController : ControllerBase
    {
        private IDosyaYonetimiService _DosyaYonetimiService;

        public DosyaYonetimiController(IDosyaYonetimiService DosyaYonetimiService)
        {
            _DosyaYonetimiService = DosyaYonetimiService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _DosyaYonetimiService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(DosyaYonetimiFilter filter)
        {
            var result = _DosyaYonetimiService.GetListWithPaging(filter);
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
        public IActionResult GetById(int DosyaYonetimiId)
        {
            var result = _DosyaYonetimiService.GetById(DosyaYonetimiId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _DosyaYonetimiService.GetMaxId();


            return Ok(result);

        }

        [HttpPost("add")]
        public IActionResult Add(DosyaYonetimi DosyaYonetimi)
        {
            var result = _DosyaYonetimiService.Add(DosyaYonetimi);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(DosyaYonetimi DosyaYonetimi)
        {
            var result = _DosyaYonetimiService.Update(DosyaYonetimi);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(DosyaYonetimi DosyaYonetimi)
        {
            var result = _DosyaYonetimiService.Delete(DosyaYonetimi);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var result = _DosyaYonetimiService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}