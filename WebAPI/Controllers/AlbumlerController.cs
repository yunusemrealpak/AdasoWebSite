using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumlerController : ControllerBase
    {
        private IAlbumlerService _albumlerService;

        public AlbumlerController(IAlbumlerService albumlerService)
        {
            _albumlerService = albumlerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _albumlerService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int albumlerId)
        {
            var result = _albumlerService.GetById(albumlerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("GetAlbumlerGUID")]

        public IActionResult GetAlbumlerGUID(string id)
        {
            var result = _albumlerService.GetAlbumlerGUID(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Albumler albumler)
        {
            var result = _albumlerService.Add(albumler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Albumler albumler)
        {
            var result = _albumlerService.Update(albumler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Albumler albumler)
        {
            var result = _albumlerService.Delete(albumler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}