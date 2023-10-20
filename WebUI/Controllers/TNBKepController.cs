using Entities.Dtos.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using WebApplication1.Models;
using WebUI.Models;
using WebUI.Models.Api;
using static Core.Utilities.Security.Encyption.SecurityKeyHelper;

namespace WebUI.Controllers
{
    public class TNBKepController : Controller
    {

        public IApiCall _apiCall;

        public TNBKepController(IApiCall apiCall)
        {
            _apiCall = apiCall;
        }


        [HttpGet]
        public IActionResult TNBKep()
        {

            return View();
        }


        [HttpPost]
        public ActionResult FormSubmit(IFormCollection collection)
        {


            //Validate Google recaptcha below 
            var response = Request.Form["g-recaptcha-response"];
            const string secret = "6Lf3QFcdAAAAAK3pgApPgxyRJDMFiEgEiAB_Z7ff";
            //Kendi Secret keyinizle değiştirin.
            string txtVKN = collection["txtVKN"];
            if (string.IsNullOrEmpty(txtVKN))
            {
                TempData["Message"] = "Vergi Numarası alanı Boş Olamaz!";
                TempData["MessageType"] = "alert alert-danger";

                return View("TNBKep");
            }

            var client = new WebClient();
            var reply =
                client.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, response));

            var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            if (!captchaResponse.Success)
            {
                TempData["Message"] = "Lütfen güvenliği doğrulayınız.";
                TempData["MessageType"] = "alert alert-danger";
            }
            else
            {
                PageItem item = new PageItem();
                firmalarFilter filter = new firmalarFilter();
                filter.VERGI_NO = txtVKN == "" ? "00" : txtVKN + "|TNBKep";
                var result = _apiCall.Post<List<view_Uye_Bilgileri>>("viewUyeBilgileri", $"getallwithpaging", filter);
                if (result.Data.Count == 0)
                {
                    TempData["MessageType"] = "alert alert-warning";
                    TempData["Message"] = "Girilien Vergi Kimlik Numarası sistemimize kayıtlı değildir.";
                }

                else
                {
                    //TNB DATA POST
                }

            }

            return View("TNBKep");
        }

    }
}
