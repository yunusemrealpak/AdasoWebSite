using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaporlarController : ControllerBase
    {
        private IRaporlarService _raporlarService;

        public RaporlarController(IRaporlarService raporlarService)
        {
            _raporlarService = raporlarService;
        }

        [HttpGet("getAll")]
        public IActionResult GetList()
        {

            var result = _raporlarService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getTipList")]
        public IActionResult GetTipList()
        {
            /*
             <option value="1">Dýþ Ticaret Raporlarý</option>
                    <option value="2">Ülke Raporlarý</option>
                    <option value="3">Sektör Raporlarý</option>                    

                    
                    <option value="6">Yatýrým Ýstatislikleri</option>
                    <option value="7">Rakamlarla Adana</option>
                    <option value="8">Odamýz Aylýk Faaliyet Raporlarý</option> 
             
            */

            var list = new List<RaporTip>
            {
                new RaporTip { Id = 1, Name = "Dýþ Ticaret Raporlarý", Image = "foreign_trade.png" },
                new RaporTip { Id = 2, Name = "Ülke Raporlarý", Image = "country_reports.png" },
                new RaporTip { Id = 3, Name = "Sektör Raporlarý", Image = "sector_reports.png" },

                new RaporTip { Id = 6, Name = "Yatýrým Ýstatislikleri", Image = "investmen_reports.png" },
                new RaporTip { Id = 7, Name = "Rakamlarla Adana", Image = "local_reports.png" },
                new RaporTip { Id = 8, Name = "Odamýz Aylýk Faaliyet Raporlarý", Image = "analyzing_reports.png" },
            };

            var result = new DataResult<List<RaporTip>>(list, true);

            return Ok(result);
        }


        [HttpPost("GetRaporTip")]
        //[CacheAspect]
        public IActionResult GetRaporTipList(RaporFilter filter)
        {

            var result = _raporlarService.GetRaporTipList(filter);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("getallwithpaging")]
        public IActionResult GetListWithPaging(RaporFilter filter)
        {
            var result = _raporlarService.GetListWithPaging(filter);
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
            var result = _raporlarService.GetMaxId();


            return Ok(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int raporlarId)
        {
            var result = _raporlarService.GetById(raporlarId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Raporlar raporlar)
        {
            var result = _raporlarService.Add(raporlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Raporlar raporlar)
        {
            var result = _raporlarService.Update(raporlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Raporlar raporlar)
        {
            var result = _raporlarService.Delete(raporlar);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}


public class RaporTip
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
}