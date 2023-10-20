using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.CrossCuttingConcerns.Caching;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazilarController : ControllerBase
    {
        private IYazilarService _yazilarService;
        private ICacheManager _cacheManager;

        public YazilarController(IYazilarService yazilarService, ICacheManager cacheManager)
        {
            _yazilarService = yazilarService;
            _cacheManager = cacheManager;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _yazilarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getPopup")]
        [CacheAspect]
        public IActionResult GetPopup()
        {
            var result = _yazilarService.GetPopup();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(YazilarFilter filter)
        {
            var result = _yazilarService.GetListWithPaging(filter);
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }
        
        
        [HttpGet("Slider")]
        public IActionResult Slider()
        {
            var result = _yazilarService.Slider();
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }

        [HttpGet("Duyurular")]
        [CacheAspect]
        public IActionResult Duyurular(/*SliderFilter SliderFilter*/)
        {
            var result = _yazilarService.Duyurular(/*SliderFilter*/);
            try
            {
                
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }


        [HttpGet("ustduyurular")]
        [CacheAspect]
        public IActionResult UstDuyurular()
        {
            var result = _yazilarService.UstDuyurular();
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
        public IActionResult GetById(int yazilarId)
        {
            var result = _yazilarService.GetById(yazilarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _yazilarService.GetMaxId();


            return Ok(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Yazilar yazilar)
        {
            var result = _yazilarService.Add(yazilar);
            if (result.Success)
            {
                _cacheManager.Remove("Business.Abstract.IYazilarService.Slider()");
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Yazilar yazilar)
        {
            var result = _yazilarService.Update(yazilar);
            if (result.Success)
            {
                _cacheManager.Remove("Business.Abstract.IYazilarService.Slider()");
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Yazilar yazilar)
        {
            var result = _yazilarService.Delete(yazilar);
            if (result.Success)
            {
                _cacheManager.Remove("Business.Abstract.IYazilarService.Slider()");
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}