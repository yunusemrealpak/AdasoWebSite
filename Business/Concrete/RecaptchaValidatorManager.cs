using Business.Abstract;
using Entities.ComplexEntities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace Business.Concrete
{
    public class RecaptchaValidatorManager : IRecaptchaValidatorService
    {
        private const string GoogleRecaptchaAddress = "https://www.google.com/recaptcha/api/siteverify";

        public readonly IConfiguration Configuration;

        public RecaptchaValidatorManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool IsRecaptchaValid(string token)
        {
            var client = new HttpClient();
            var response = client.GetStringAsync($@"{GoogleRecaptchaAddress}?secret={Configuration["Google:RecaptchaV3SecretKey"]}&response={token}").Result;
            var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);

            if (!recaptchaResponse.Success || recaptchaResponse.Score < Convert.ToDecimal(Configuration["Google:RecaptchaMinScore"]))
            {
                return false;
            }
            return true;
        }

    }
}