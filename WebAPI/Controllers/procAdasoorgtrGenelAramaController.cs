using Business.Abstract;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class procAdasoorgtrGenelAramaController : ControllerBase
    {
        private Iproc_Adaso_org_tr_GenelAramaService _proc_Adaso_org_tr_GenelAramaService;

        public procAdasoorgtrGenelAramaController(Iproc_Adaso_org_tr_GenelAramaService proc_Adaso_org_tr_GenelAramaService)
        {
            _proc_Adaso_org_tr_GenelAramaService = proc_Adaso_org_tr_GenelAramaService;
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(SearchFilter kendoAutoComplete)
        {
            var result = _proc_Adaso_org_tr_GenelAramaService.GetListWithPaging(kendoAutoComplete);
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