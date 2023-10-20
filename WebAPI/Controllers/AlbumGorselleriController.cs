using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumGorselleriController : ControllerBase
    {
        private IAlbumGorselleriService _albumGorselleriService;

        public AlbumGorselleriController(IAlbumGorselleriService albumGorselleriService)
        {
            _albumGorselleriService = albumGorselleriService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _albumGorselleriService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int albumGorselleriId)
        {
            var result = _albumGorselleriService.GetById(albumGorselleriId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyGuID")]

        public IActionResult GetAlbumGorselleriIDList(string id)
        {
            var result = _albumGorselleriService.GetAlbumGorselleriIDList(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(AlbumGorselleri albumGorselleri)
        {
            var result = _albumGorselleriService.Add(albumGorselleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(AlbumGorselleri albumGorselleri)
        {
            var result = _albumGorselleriService.Update(albumGorselleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(AlbumGorselleri albumGorselleri)
        {
            var result = _albumGorselleriService.Delete(albumGorselleri);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}