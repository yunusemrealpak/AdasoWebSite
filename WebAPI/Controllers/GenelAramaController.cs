using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenelAramaController : ControllerBase
    {
        private Iproc_Adaso_org_tr_GenelAramaService _proc_Adaso_org_tr_GenelAramaService;

        public GenelAramaController(Iproc_Adaso_org_tr_GenelAramaService proc_Adaso_org_tr_GenelAramaService)
        {
            _proc_Adaso_org_tr_GenelAramaService = proc_Adaso_org_tr_GenelAramaService;
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(SearchFilter filter)
        {
            var result = _proc_Adaso_org_tr_GenelAramaService.GetListWithPaging(filter);
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