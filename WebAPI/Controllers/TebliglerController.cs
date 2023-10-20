using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TebliglerController : ControllerBase
    {
        private ITebliglerService _tebliglerService;

        public TebliglerController(ITebliglerService tebliglerService)
        {
            _tebliglerService = tebliglerService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _tebliglerService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _tebliglerService.GetMaxId();


            return Ok(result);

        }
        [HttpGet("GetListAnaSayfaTebliglerTab")]
        public IActionResult GetListAnaSayfaTebliglerTab()
        {

            var result = _tebliglerService.GetListAnaSayfaTebliglerTab();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int tebliglerId)
        {
            var result = _tebliglerService.GetById(tebliglerId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Tebligler tebligler)
        {
            var result = _tebliglerService.Add(tebligler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Tebligler tebligler)
        {
            var result = _tebliglerService.Update(tebligler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Tebligler tebligler)
        {
            var result = _tebliglerService.Delete(tebligler);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var result = _tebliglerService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(TebliglerFilter filter)
        {
            var result = _tebliglerService.GetListWithPaging(filter);
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