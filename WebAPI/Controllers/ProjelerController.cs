using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjelerController : ControllerBase
    {
        private IProjelerService _projelerService;

        public ProjelerController(IProjelerService projelerService)
        {
            _projelerService = projelerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _projelerService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int projelerId)
        {
            var result = _projelerService.GetById(projelerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(YazilarFilter filter)
        {
            var result = _projelerService.GetListWithPaging(filter);
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
            var result = _projelerService.GetMaxId();


            return Ok(result);

        }
        [HttpPost("add")]
        public IActionResult Add(Projeler projeler)
        {
            var result = _projelerService.Add(projeler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Projeler projeler)
        {
            var result = _projelerService.Update(projeler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Projeler projeler)
        {
            var result = _projelerService.Delete(projeler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var silinecekData = _projelerService.GetById(id);
            if (silinecekData == null && silinecekData.Data != null && silinecekData.Success)
            {
                return BadRequest();
            }
            var result = _projelerService.Delete(silinecekData.Data);
            if (result.Success)
            {
                return Ok(result);
            }


            return BadRequest();
        }
    }
}