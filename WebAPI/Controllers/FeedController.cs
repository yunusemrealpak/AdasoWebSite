using Business.Abstract;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private IEtkinliklerService _etkinliklerService;
        private IYazilarService _yazilarService;
        private ITDHaberlerService _tDHaberlerService;

        public FeedController(IYazilarService yazilarService, IEtkinliklerService etkinliklerService, ITDHaberlerService tDHaberlerService)
        {
            _etkinliklerService = etkinliklerService;
            _yazilarService = yazilarService;
            _tDHaberlerService = tDHaberlerService;
        }

        [HttpGet("getFeed")]
        public IActionResult GetFeed()
        {
            Task<List<Etkinlikler>> etkinliklerTask = _etkinliklerService.GetListAsync(5);
            Task<List<DuyurularUI>> duyurularTask = _yazilarService.GetListAsync(5);
            Task<List<TDHaberler>> haberlerTask = _tDHaberlerService.GetListAsync(5);

            Task.WaitAll(etkinliklerTask, duyurularTask);

            var etkinlikler = etkinliklerTask.Result;
            var duyurular = duyurularTask.Result;
            var haberler = haberlerTask.Result;

            Feed feed = new Feed();
            feed.Etkinlikler = etkinlikler;
            feed.Duyurular = duyurular;
            feed.Haberler = haberler;

            var result = new DataResult<Feed>(feed, true);

            return Ok(result.Data);
        }
    }
}

// Gerekli yere taşınacak
class Feed
{
    public List<Etkinlikler> Etkinlikler { get; set; }
    public List<DuyurularUI> Duyurular { get; set; }
    public List<TDHaberler> Haberler { get; set; }
}