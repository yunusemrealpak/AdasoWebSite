using System.Text.RegularExpressions;

namespace Helper
{
    public class UrlHelper_
    {
        public static string FriendlyURLTitle(string incomingText)
        {

            if (incomingText != null)
            {
                incomingText = incomingText.Replace("ş", "s");
                incomingText = incomingText.Replace("Ş", "s");
                incomingText = incomingText.Replace("İ", "i");
                incomingText = incomingText.Replace("I", "i");
                incomingText = incomingText.Replace("ı", "i");
                incomingText = incomingText.Replace("ö", "o");
                incomingText = incomingText.Replace("Ö", "o");
                incomingText = incomingText.Replace("ü", "u");
                incomingText = incomingText.Replace("Ü", "u");
                incomingText = incomingText.Replace("Ç", "c");
                incomingText = incomingText.Replace("ç", "c");
                incomingText = incomingText.Replace("ğ", "g");
                incomingText = incomingText.Replace("Ğ", "g");
                incomingText = incomingText.Replace(" ", "-");
                incomingText = incomingText.Replace("---", "-");
                incomingText = incomingText.Replace("?", "");
                incomingText = incomingText.Replace("/", "");
                incomingText = incomingText.Replace(".", "");
                incomingText = incomingText.Replace("'", "");
                incomingText = incomingText.Replace("#", "");
                incomingText = incomingText.Replace("%", "");
                incomingText = incomingText.Replace("&", "");
                incomingText = incomingText.Replace("*", "");
                incomingText = incomingText.Replace("!", "");
                incomingText = incomingText.Replace("@", "");
                incomingText = incomingText.Replace("+", "");
                incomingText = incomingText.ToLower();
                incomingText = incomingText.Trim();
                // tüm harfleri küçült
                string encodedUrl = (incomingText ?? "").ToLower();
                // & ile " " yer değiştirme
                encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");
                // " " karakterlerini silme
                encodedUrl = encodedUrl.Replace("'", "");
                // geçersiz karakterleri sil
                encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");
                // tekrar edenleri sil
                encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");
                // karakterlerin arasına tire koy
                encodedUrl = encodedUrl.Trim('-');
                return encodedUrl;
            }
            else
            {
                return "";
            }
        }
        public static string SeoAdress(object a)
        {
            string s = a.ToString();

            //s = oncul + id + "-" + s;
            if (string.IsNullOrEmpty(s)) //string yok veya boş ise true döndürür
            {
                return "";
            }

            //if (s.Length > 80)
            //{
            //    s = s.Substring(0, 80); //string den belli karakter alır.
            //}
            s = s.ToLower();
            s = s.Replace("ş", "s"); //karakter değişimi için kullanılır
            s = s.Replace("Ş", "S");
            s = s.Replace("ğ", "g");
            s = s.Replace("Ğ", "G");
            s = s.Replace("İ", "I");
            s = s.Replace("ı", "i");
            s = s.Replace("ç", "c");
            s = s.Replace("Ç", "C");
            s = s.Replace("ö", "o");
            s = s.Replace("Ö", "O");
            s = s.Replace("ü", "u");
            s = s.Replace("Ü", "U");

            s = s.Replace("'", "");
            s = s.Replace("\"", "");
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            //if (r.IsMatch(s))
            s = r.Replace(s, "-");
            if (!string.IsNullOrEmpty(s))
                while (s.IndexOf("--") > -1)
                    s = s.Replace("--", "-");
            if (s.StartsWith("-")) s = s.Substring(1);
            if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
            return s;
        }
    }
}
