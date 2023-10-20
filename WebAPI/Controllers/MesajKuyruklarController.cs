using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MesajKuyruklarController : ControllerBase
    {
        private IMesajKuyruklarService _MesajKuyruklarService;

        public MesajKuyruklarController(IMesajKuyruklarService MesajKuyruklarService)
        {
            _MesajKuyruklarService = MesajKuyruklarService;
        }

        [HttpPost("add")]
        public IActionResult Add(MesajKuyruklar MesajKuyruklar)
        {
            var result = _MesajKuyruklarService.Add(MesajKuyruklar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

    }
}