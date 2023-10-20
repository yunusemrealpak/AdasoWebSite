using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {
        private IYoutubeService _youtubeService;

        public YoutubeController(IYoutubeService YoutubeService)
        {
            _youtubeService = YoutubeService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _youtubeService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(YoutubeFilter filter)
        {
            var result = _youtubeService.GetListWithPaging(filter);
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
        public IActionResult GetById(int youtubeId)
        {
            var result = _youtubeService.GetById(youtubeId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _youtubeService.GetMaxId();


            return Ok(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Youtube Youtube)
        {
            var result = _youtubeService.Add(Youtube);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Youtube Youtube)
        {
            var result = _youtubeService.Update(Youtube);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Youtube Youtube)
        {
            var result = _youtubeService.Delete(Youtube);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}