using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GazetelerController : ControllerBase
    {
        private IGazetelerService _gazetelerService;

        public GazetelerController(IGazetelerService gazetelerService)
        {
            _gazetelerService = gazetelerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _gazetelerService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("GetListHomePageMagazine")]
        public IActionResult GetListHomePageMagazine()
        {

            var result = _gazetelerService.GetListHomePageMagazine();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int gazetelerId)
        {
            var result = _gazetelerService.GetById(gazetelerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(GazetelerFilter filter)
        {
            var result = _gazetelerService.GetListWithPaging(filter);
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
            var result = _gazetelerService.GetMaxId();


            return Ok(result);

        }

        [HttpPost("add")]
        public IActionResult Add(Gazeteler gazeteler)
        {
            var result = _gazetelerService.Add(gazeteler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Gazeteler gazeteler)
        {
            var result = _gazetelerService.Update(gazeteler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Gazeteler gazeteler)
        {
            var result = _gazetelerService.Delete(gazeteler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}