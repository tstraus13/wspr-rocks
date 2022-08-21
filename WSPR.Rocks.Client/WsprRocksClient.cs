using System.Text;
using System.Text.Json;
using System.Net;
using WSPR.Rocks.Client.Models;

namespace WSPR.Rocks.Client;

public class WsprRocksClient
{
    private HttpClient _httpClient;
    private int _retryDelay;

    public WsprRocksClient(string baseAddress = "http://wd1.wspr.rocks", int retryDelay = 1000)
    {
        _httpClient = new HttpClient() {
            BaseAddress = new Uri(baseAddress),
        };

        _httpClient.DefaultRequestHeaders.Add("host", "wd1.wspr.rocks");
        _httpClient.DefaultRequestHeaders.Add("origin", "http://wspr.rocks");
        _httpClient.DefaultRequestHeaders.Add("referer", "http://wspr.rocks/");
        _httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (X11; Fedora; Linux x86_64; rv:97.0) Gecko/20100101 Firefox/97.0");

        _retryDelay = retryDelay;
    }

    public async Task<SearchResponse?> Search()
    {
        return await Search(new SearchRequest());
    }

    public async Task<SearchResponse?> Search(SearchRequest request)
    {
        if (request == null)
            request = new SearchRequest();

        var queryString = new List<KeyValuePair<string,string>>();

        queryString.Add(new KeyValuePair<string, string>("parms", request.Parms.ToString().ToLower()));
        queryString.Add(new KeyValuePair<string, string>("balloons", (request.Balloons ? "show" : "hide")));
        queryString.Add(new KeyValuePair<string, string>("rxCall", request.RxCall));
        queryString.Add(new KeyValuePair<string, string>("txCall", request.TxCall));
        queryString.Add(new KeyValuePair<string, string>("count", request.Count.ToString()));
        queryString.Add(new KeyValuePair<string, string>("mode", request.Mode));
        queryString.Add(new KeyValuePair<string, string>("band", request.Band));
        queryString.Add(new KeyValuePair<string, string>("hours", request.Hours));
        queryString.Add(new KeyValuePair<string, string>("unique", request.Unique.ToString().ToLower()));
        queryString.Add(new KeyValuePair<string, string>("advanced", request.Advanced));
        queryString.Add(new KeyValuePair<string, string>("version_search", request.VersionSearch.ToString().ToLower()));
 
        var data = await ExecutePostWithReturn<SearchResponse>($"/api/clickhouse/", queryString);

        return data;
    }

    private async Task<T?> ExecuteGet<T>(string apiPath)
    {
        HttpResponseMessage response;
        int retry = 5;

        do
        {
            if (retry != 5)
                await Task.Delay(_retryDelay);

            response = await _httpClient.GetAsync(apiPath);

            retry--;
        } while (response.StatusCode != HttpStatusCode.OK && retry > 0);

        if (response.StatusCode != HttpStatusCode.OK)
            return default(T);

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<T>(responseContent);

        return result;
    }

    private async void ExecutePost<T>(string apiPath, T data)
    {
        HttpResponseMessage response;
        int retry = 5;

        var json = JsonSerializer.Serialize(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        do
        {
            if (retry != 5)
                await Task.Delay(_retryDelay);

            response = await _httpClient.PostAsync(apiPath, content);

            retry--;
        } while (response.StatusCode != HttpStatusCode.OK && retry > 0);

        response.EnsureSuccessStatusCode();
    }

    private async Task<T?> ExecutePostWithReturn<T>(string apiPath, List<KeyValuePair<string,string>> body)
    {
        HttpResponseMessage response;
        int retry = 5;

        var content = new FormUrlEncodedContent(body);
        
        do
        {
            if (retry != 5)
                await Task.Delay(_retryDelay);

            response = await _httpClient.PostAsync(apiPath, content);

            retry--;
        } while (response.StatusCode != HttpStatusCode.OK && retry > 0);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonSerializer.Deserialize<T>(responseContent);

        return result;
    }

    private async Task<R?> ExecutePostWithReturn<T,R>(string apiPath, T data)
    {
        HttpResponseMessage response;
        int retry = 5;

        var json = JsonSerializer.Serialize<T>(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        do
        {
            if (retry != 5)
                await Task.Delay(_retryDelay);

            response = await _httpClient.PostAsync(apiPath, content);

            retry--;
        } while (response.StatusCode != HttpStatusCode.OK && retry > 0);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<R>(responseContent);

        return result;
    }
}
