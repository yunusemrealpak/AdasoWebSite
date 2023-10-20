using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtkinliklerController : ControllerBase
    {
        private IEtkinliklerService _etkinliklerService;

        public EtkinliklerController(IEtkinliklerService etkinliklerService)
        {
            _etkinliklerService = etkinliklerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _etkinliklerService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }
        [HttpPost("GetListHomePageActives")]
        public IActionResult GetListHomePageActives(FilterFullCalendar filter)
        {
            var result = _etkinliklerService.GetListHomePageActives(filter);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(YazilarFilter filter)
        {
            var result = _etkinliklerService.GetListWithPaging(filter);
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
        public IActionResult GetById(int etkinliklerId)
        {
            var result = _etkinliklerService.GetById(etkinliklerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _etkinliklerService.GetMaxId();


            return Ok(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Etkinlikler etkinlikler)
        {
            var result = _etkinliklerService.Add(etkinlikler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Etkinlikler etkinlikler)
        {
            var result = _etkinliklerService.Update(etkinlikler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Etkinlikler etkinlikler)
        {
            var result = _etkinliklerService.Delete(etkinlikler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}