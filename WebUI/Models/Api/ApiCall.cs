using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Models.Api
{
    public interface IApiCall
    {
        ResponseMessage<T> Get<T>(string Controller, string Action, string Area = null);
        ResponseMessage<T> PUT<T>(string Controller, string Action, string Area = null);
        ResponseMessage<T> Post<T>(string Controller, string Action, object data, string Area = null);
        Task<string> StreamWithNewtonsoftJson(string uri, HttpClient httpClient);
    }

    public class ApiCall : IApiCall
    {
        //public string ApiUrl { get; set; } = "http://localhost:52739/api";

        public string ApiUrl { get; set; } = "http://api.adaso.org.tr/api";

        public string EodaUrl { get; set; } = "http://eoda.adaso.org.tr/AdasoWebYonetimKurulu?KullaniciAdi=Administrator&Sifre=**00**&bos=0";

        [HttpGet]
        public ResponseMessage<T> Get<T>(string Controller, string Action, string Area = null)
        {
            HttpClient client = new HttpClient();
            if (String.IsNullOrEmpty(Area))
            {
                var response = client.GetStringAsync(String.Format("{0}/{1}/{2}", ApiUrl, Controller, Action, Encoding.UTF8, "application/json")).Result;
                var result = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);
                return result;
            }
            else
            {
                var response = client.GetStringAsync(String.Format("{0}/{1}/{2}/{3}", ApiUrl, Area, Controller, Action, Encoding.UTF8)).Result;
                var result = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);

                return result;
            }
        }

        public ResponseMessage<T> Post<T>(string Controller, string Action, object data, string Area = null)
        {
            Uri baseUrl = new Uri(ApiUrl);
            IRestClient client = new RestClient(ApiUrl);

            RestRequest req;
            if (String.IsNullOrEmpty(Area))
            {
                req = new RestRequest(String.Format("/{0}/{1}", Controller, Action), Method.POST);
            }
            else
            {
                req = new RestRequest(String.Format("/{0}/{1}/{2}", Area, Controller, Action), Method.POST);
            }

            req.AddJsonBody(JsonConvert.SerializeObject(data));
            var response = client.Execute<string>(req);

            if (response.IsSuccessful)
            {
                if (string.IsNullOrEmpty(response.Content))
                {
                    Console.WriteLine("Geri dönüş değeri ayarlanmadı.");
                    return null;
                }
                return JsonConvert.DeserializeObject<ResponseMessage<T>>(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
            }

            return null;
        }

        public ResponseMessage<T> PUT<T>(string Controller, string Action, string Area = null)
        {
            HttpClient client = new HttpClient();
            if (String.IsNullOrEmpty(Area))
            {
                var response = client.GetStringAsync(String.Format("{0}/{1}/{2}", ApiUrl, Controller, Action, Method.POST)).Result;
                var result = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);

                return result;
            }
            else
            {
                var response = client.GetStringAsync(String.Format("{0}/{1}/{2}/{3}", ApiUrl, Area, Controller, Action, Encoding.UTF8)).Result;
                var result = JsonConvert.DeserializeObject<ResponseMessage<T>>(response);
                return result;
            }
        }

        public async Task<string> StreamWithNewtonsoftJson(string uri, HttpClient httpClient)
        {
            using var httpResponse = await httpClient.GetAsync(uri, HttpCompletionOption.ResponseHeadersRead);

            httpResponse.EnsureSuccessStatusCode(); // throws if not 200-299

            if (httpResponse.Content is object && httpResponse.Content.Headers.ContentType.MediaType == "application/json")
            {
                var contentStream = await httpResponse.Content.ReadAsStreamAsync();

                using var streamReader = new StreamReader(contentStream);
                using var jsonReader = new JsonTextReader(streamReader);

                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    string a = serializer.Deserialize<string>(jsonReader);

                    return serializer.Deserialize<string>(jsonReader);
                }
                catch (JsonReaderException)
                {
                    Console.WriteLine("Invalid JSON.");
                }
            }
            else
            {
                Console.WriteLine("HTTP Response was invalid and cannot be deserialised.");
            }

            return null;
        }

    }
}