using System.Linq;
using WebApplication1.Business.Interfaces;

namespace WebApplication1.Business
{
    public class UrlBusiness : IUrlBusiness
    {
        private static readonly Dictionary<int, string> UrlDictionary = new Dictionary<int, string>();
        private static int UrlShort = 0;
        public string GetShortUrl(string url)
        {
            try
            {
                var newUrl = "www.shortUrl.com/";
                if (UrlDictionary.ContainsValue(url))
                {
                    return newUrl +
                           UrlDictionary.First(x => x.Value == url).Key;
                }

                UrlShort++;
                UrlDictionary.Add(UrlShort, url);

                return newUrl + UrlShort;
            }
            catch (Exception e)
            {
                throw new Exception("Error on GetShortUrl");
            }

        }

        public string GetLongUrl(string url)
        {
            try
            {
                var code = int.Parse(url.Split("/")[1]);

                if (UrlDictionary.ContainsKey(code))
                {
                    return UrlDictionary.GetValueOrDefault(code);
                }

                //TODO make a custom exception
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception("Error on GetLongURL");
            }

        }
    }
}
