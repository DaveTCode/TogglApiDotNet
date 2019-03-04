using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TogglApi.Client
{
    public class BaseRequestConfig
    {
        protected Dictionary<string, object> UrlParameters { get; } = new Dictionary<string, object>();

        private readonly string _baseUrl;

        protected BaseRequestConfig(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        internal string GenerateUrl()
        {
            var url = new StringBuilder($"{_baseUrl}?");
            var firstElement = true;

            foreach (var urlParam in UrlParameters.Where(pair => pair.Value != null))
            {
                if (firstElement)
                {
                    firstElement = false;
                    url.Append($"{urlParam.Key}={WebUtility.UrlEncode(urlParam.Value.ToString())}");
                }
                else
                {
                    url.Append($"&{urlParam.Key}={WebUtility.UrlEncode(urlParam.Value.ToString())}");
                }
            }

            return url.ToString();
        }
    }
}
