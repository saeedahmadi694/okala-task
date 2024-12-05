using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Text;

namespace okala_task.Utilities;

public class HttpRequest : IHttpRequest
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpRequest(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    private HttpClient CreateHttpClient(Dictionary<string, string>? headers = null, int timeoutMinutes = 5)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.Timeout = TimeSpan.FromMinutes(timeoutMinutes);

        if (headers != null)
        {
            foreach (var header in headers)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }

        return httpClient;
    }

    private void HandleErrorResponse(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            string errorMessage = response.StatusCode switch
            {
                HttpStatusCode.UnprocessableEntity or HttpStatusCode.BadRequest => "InvalidInputException",
                _ => $"InvalidInputException => StatusCode : {response.StatusCode}"
            };

            throw new Exception(errorMessage);
        }
    }

    private StringContent CreateJsonContent(object model)
    {
        var json = JsonConvert.SerializeObject(model, new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        });
        return new StringContent(json, Encoding.UTF8, "application/json");
    }

    public async Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null, int timeoutMinutes = 5)
    {
        var httpClient = CreateHttpClient(headers, timeoutMinutes);
        var response = await httpClient.GetAsync(url);
        HandleErrorResponse(response);

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content)!;
    }

    public async Task<T> PostAsync<T>(string url, object model, Dictionary<string, string>? headers = null)
    {
        var httpClient = CreateHttpClient(headers);
        var response = await httpClient.PostAsync(url, CreateJsonContent(model));
        HandleErrorResponse(response);

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content)!;
    }

    public async Task<T> PutAsync<T>(string url, object model, Dictionary<string, string>? headers = null)
    {
        var httpClient = CreateHttpClient(headers);
        var response = await httpClient.PutAsync(url, CreateJsonContent(model));
        HandleErrorResponse(response);

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content)!;
    }

    public async Task DeleteAsync(string url, Dictionary<string, string>? headers = null)
    {
        var httpClient = CreateHttpClient(headers);
        var response = await httpClient.DeleteAsync(url);
        HandleErrorResponse(response);
    }

    public async Task PostAsync(string url, object model, Dictionary<string, string>? headers = null)
    {
        var httpClient = CreateHttpClient(headers);
        var response = await httpClient.PostAsync(url, CreateJsonContent(model));
        HandleErrorResponse(response);
    }

    public async Task GetAsync(string url, Dictionary<string, string>? headers = null)
    {
        var httpClient = CreateHttpClient(headers);
        var response = await httpClient.GetAsync(url);
        HandleErrorResponse(response);
    }

    public async Task PutAsync(string url, object model, Dictionary<string, string>? headers = null)
    {
        var httpClient = CreateHttpClient(headers);
        var response = await httpClient.PutAsync(url, CreateJsonContent(model));
        HandleErrorResponse(response);
    }
}
