using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TDHaberlerController : ControllerBase
    {
        private ITDHaberlerService _tDHaberlerService;

        public TDHaberlerController(ITDHaberlerService tDHaberlerService)
        {
            _tDHaberlerService = tDHaberlerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _tDHaberlerService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(YazilarFilter filter)
        {
            var result = _tDHaberlerService.GetListWithPaging(filter);
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
            var result = _tDHaberlerService.GetMaxId();


            return Ok(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int tDHaberlerId)
        {
            var result = _tDHaberlerService.GetById(tDHaberlerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(TDHaberler tDHaberler)
        {
            var result = _tDHaberlerService.Add(tDHaberler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(TDHaberler tDHaberler)
        {
            var result = _tDHaberlerService.Update(tDHaberler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(TDHaberler tDHaberler)
        {
            var result = _tDHaberlerService.Delete(tDHaberler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}