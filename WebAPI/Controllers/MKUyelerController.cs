using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MKUyelerController : ControllerBase
    {
        private IMKUyelerService _mKUyelerService;

        public MKUyelerController(IMKUyelerService mKUyelerService)
        {
            _mKUyelerService = mKUyelerService;
        }

        [HttpGet("getall")]
        /// <summary>
        /// Deneme Veri Getirir.
        /// </summary>
        /// <returns></returns>
        public IActionResult GetList()
        {
            var result = _mKUyelerService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int mKUyelerId)
        {
            var result = _mKUyelerService.GetById(mKUyelerId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(MkUyelerFilter filter)
        {
            var result = _mKUyelerService.GetListWithPaging(filter);
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(result);
            }
        }

    }
}