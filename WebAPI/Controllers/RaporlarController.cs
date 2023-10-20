using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporlarController : ControllerBase
    {
        private IRaporlarService _raporlarService;

        public RaporlarController(IRaporlarService raporlarService)
        {
            _raporlarService = raporlarService;
        }

        [HttpGet("getAll")]
        public IActionResult GetList()
        {

            var result = _raporlarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("GetRaporTip")]
        //[CacheAspect]
        public IActionResult GetRaporTipList(RaporFilter filter)
        {

            var result = _raporlarService.GetRaporTipList(filter);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(RaporFilter filter)
        {
            var result = _raporlarService.GetListWithPaging(filter);
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
            var result = _raporlarService.GetMaxId();


            return Ok(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int raporlarId)
        {
            var result = _raporlarService.GetById(raporlarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Raporlar raporlar)
        {
            var result = _raporlarService.Add(raporlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Raporlar raporlar)
        {
            var result = _raporlarService.Update(raporlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Raporlar raporlar)
        {
            var result = _raporlarService.Delete(raporlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}