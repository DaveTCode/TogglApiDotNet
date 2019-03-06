using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using TogglApi.Client.Exceptions;

namespace TogglApi.Client
{
    public abstract class BaseTogglClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger _logger;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        protected BaseTogglClient(HttpClient httpClient, ILogger logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<T> GetGenericReportApi<T>(string url, string apiToken)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiToken}:api_token")));

            var retries = 0;
            const int maxRetries = 3;
            while (retries < maxRetries)
            {
                var response = await _httpClient.SendAsync(request);

                // Dotnet standard doesn't have TooManyRequests on the API - c.f. https://github.com/dotnet/corefx/issues/17149
                if (response.StatusCode == (HttpStatusCode)429)
                {
                    _logger.Info("Rate limited request, pausing before retrying");
                    await Task.Delay(1000 * (retries + 1));
                    retries++;
                    continue;
                }

                if (response.IsSuccessStatusCode)
                {
                    _logger.Debug("Request to url {} was a success with status code {}", url, response.StatusCode);

                    return JsonConvert.DeserializeObject<T>(
                        await response.Content.ReadAsStringAsync(),
                        _jsonSerializerSettings);
                }

                try
                {
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException e)
                {
                    throw new TogglApiException($"Request to url {url} failed with status code {response.StatusCode}", e);
                }
            }

            _logger.Error("Rate limited for {} requests so failing", maxRetries);
            throw new TogglApiException($"Rate limited {maxRetries} times in a row");
        }
    }
}
