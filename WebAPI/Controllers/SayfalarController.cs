using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SayfalarController : ControllerBase
    {
        private ISayfalarService _sayfalarService;

        public SayfalarController(ISayfalarService sayfalarService)
        {
            _sayfalarService = sayfalarService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _sayfalarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getlistpagetitle")]
        [CacheAspect]
        public IActionResult GetListPageTitle()
        {
            var result = _sayfalarService.GetListPageTitle();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int sayfalarId)
        {
            var result = _sayfalarService.GetById(sayfalarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbySayfaURL")]
        public IActionResult GetBySayfaURL(string baslik)
        {
            var result = _sayfalarService.GetBySayfaURL(baslik);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Sayfalar sayfalar)
        {
            var result = _sayfalarService.Add(sayfalar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Sayfalar sayfalar)
        {
            var result = _sayfalarService.Update(sayfalar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Sayfalar sayfalar)
        {
            var result = _sayfalarService.Delete(sayfalar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("getallwithpaging")]
        [CacheAspect]
        public IActionResult GetListWithPaging(SayfalarFilter filter)
        {
            var result = _sayfalarService.GetListWithPaging(filter);
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
            var result = _sayfalarService.GetMaxId();


            return Ok(result);

        }
    }
}