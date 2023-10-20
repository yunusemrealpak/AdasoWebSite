using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace Helper
{
    public static class UserHelper
    {


        #region yetkilendirme giriş

        private static string UygulamaAdi { get; set; } = "2";

        public static bool IsCurrentUser()
        {
            try
            {
                if (UserHelper.GetCurrentUser() == null || UserHelper.GetCurrentUser().personelID == 0)
                {
                    return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static LoginResult GetCurrentUser()
        {
            LoginResult user = (LoginResult)HttpContext.Current.Session["user"];
            return ((LoginResult)HttpContext.Current.Session["user"]);
        }


        public static string UserLogin(string personelEmail, string personelSifre)
        {
            LoginResult result = new LoginResult();
            string resp = "";
            try
            {

                using (var client = new HttpClient())
                {
                    string uri = "https://api.adasoportal.com/";
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response;
                    response = client.GetAsync("api/personel/personellogin/" + personelEmail + "/" + personelSifre + "/" + UygulamaAdi).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        resp = response.Content.ReadAsStringAsync().Result;
                        //result = JsonConvert.DeserializeObject<LoginResult>(resp);
                    }
                    else
                    {
                        result.personelID = 0;
                        result.messageState = false;
                        result.messageCode = "100";
                        result.messageDescription = "İşlem sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.!";
                    }
                }
            }
            catch (Exception ex)
            {
                result.personelID = 0;
                result.messageState = false;
                result.messageCode = "200";
                result.messageDescription = "İşlem sırasında bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.! (Detay :" + ex.Message + ")";
            }
            //HttpContext.Current.Session.Add("user", result);
            return resp;
        }

        private static T JsonConvertToModel<T>(string val)
        {
            string result2 = val.ToJsonDeserialize<string>();
            var result = result2.ToJsonDeserialize<T>();
            return result;
        }
        #endregion
    }
    public partial class LoginResult : MessageResult
    {
        public int personelID { get; set; }
        public string personelAdi { get; set; }
        public string personelSoyadi { get; set; }
        public string personelUnvan { get; set; }
        public string personelMail { get; set; }
        public string yetkiBaslik { get; set; }
    }
    public partial class MessageResult
    {
        public bool messageState { get; set; }
        public string messageCode { get; set; }
        public string messageDescription { get; set; }
    }

    public static class KullaniciYetkileri
    {
        public static string SistemYoneticisi { get { return "Sistem yöneticisi"; } set { } }
        public static string Yonetici { get { return "Yönetici"; } set { } }
        public static string Standart { get { return "Standart"; } set { } }
        public static string Stajer { get { return "Stajer"; } set { } }
        public static string Ziyaretci { get { return "Ziyaretçi"; } set { } }
    }
}