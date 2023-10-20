using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication1.Models;
using WebUI.Models.Api;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TumUyelerController : Controller
    {

        public IApiCall _apiCall;
        public TumUyelerController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OutsourceViewJson(firmalarFilter kendotable)
        {
            kendotable.unvan = "";
            var result = _apiCall.Post<List<View_Base_OFirmalar>>("OutsourceView", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }

        public IActionResult view_Uye_BilgileriJSON(firmalarFilter kendotable)
        {

            var result = _apiCall.Post<List<view_Uye_Bilgileri>>("viewUyeBilgileri", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
        public IActionResult mkUyelerJSON(MkUyelerFilter kendotable)
        {

            var result = _apiCall.Post<List<MKUyeler>>("MKUyeler", $"getallwithpaging", kendotable);
            //if (result.Success)
            //{
            return Json(new { data = result.Data, total_length = result.DataCount });
            //}
            //return Json("");
        }
    }
}
