using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullanicilarController : ControllerBase
    {
        private IKullanicilarService _kullanicilarService;

        public KullanicilarController(IKullanicilarService kullanicilarService)
        {
            _kullanicilarService = kullanicilarService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _kullanicilarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int kullanicilarId)
        {
            var result = _kullanicilarService.GetById(kullanicilarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Kullanicilar kullanicilar)
        {
            var result = _kullanicilarService.Add(kullanicilar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Kullanicilar kullanicilar)
        {
            var result = _kullanicilarService.Update(kullanicilar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Kullanicilar kullanicilar)
        {
            var result = _kullanicilarService.Delete(kullanicilar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}