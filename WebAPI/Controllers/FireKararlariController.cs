using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireKararlariController : ControllerBase
    {
        private IFireKararlariService _fireKararlariService;

        public FireKararlariController(IFireKararlariService fireKararlariService)
        {
            _fireKararlariService = fireKararlariService;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {

            var result = _fireKararlariService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(FireKararlariFilter filter)
        {
            var result = _fireKararlariService.GetListWithPaging(filter);
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
        public IActionResult GetById(int fireKararlariId)
        {
            var result = _fireKararlariService.GetById(fireKararlariId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getmaxid")]
        public IActionResult GetMaxId()
        {
            var result = _fireKararlariService.GetMaxId();


            return Ok(result);

        }

        [HttpPost("add")]
        public IActionResult Add(FireKararlari fireKararlari)
        {
            var result = _fireKararlariService.Add(fireKararlari);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(FireKararlari fireKararlari)
        {
            var result = _fireKararlariService.Update(fireKararlari);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(FireKararlari fireKararlari)
        {
            var result = _fireKararlariService.Delete(fireKararlari);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("deletebyid")]
        public IActionResult DeleteById(int id)
        {
            var result = _fireKararlariService.DeleteById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}