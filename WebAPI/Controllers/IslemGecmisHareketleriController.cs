using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IslemGecmisHareketleriController : ControllerBase
    {
        private IIslemGecmisHareketleriService _ıslemGecmisHareketleriService;

        public IslemGecmisHareketleriController(IIslemGecmisHareketleriService ıslemGecmisHareketleriService)
        {
            _ıslemGecmisHareketleriService = ıslemGecmisHareketleriService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _ıslemGecmisHareketleriService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int ıslemGecmisHareketleriId)
        {
            var result = _ıslemGecmisHareketleriService.GetById(ıslemGecmisHareketleriId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpGet("getTableList")]
        public IActionResult GetTableId(int id)
        {
            var result = _ıslemGecmisHareketleriService.GetTableList(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(IslemGecmisHareketleri ıslemGecmisHareketleri)
        {
            var result = _ıslemGecmisHareketleriService.Add(ıslemGecmisHareketleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(IslemGecmisHareketleri ıslemGecmisHareketleri)
        {
            var result = _ıslemGecmisHareketleriService.Update(ıslemGecmisHareketleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(IslemGecmisHareketleri ıslemGecmisHareketleri)
        {
            var result = _ıslemGecmisHareketleriService.Delete(ıslemGecmisHareketleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}