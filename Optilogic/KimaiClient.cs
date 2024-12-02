using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

public class KimaiClient
{
    private readonly HttpClient _client;

    private const string BaseUrl = "http://192.168.201.5:8001/api/"; // Replace with your Kimai URL
    private const string ApiKey = "b15482380f0d11c74d9df58cd";
    private const string Username = "MMI";

    public KimaiClient()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Add("X-AUTH-USER", Username);
        _client.DefaultRequestHeaders.Add("X-AUTH-TOKEN", ApiKey);
    }

    public async Task<JArray> FetchTimesheetsByActivityId(string activityName)
    {
        // Remove the start and end date parameters
        var url = $"{BaseUrl}/timesheets?activity={activityName}";
        var response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JArray.Parse(content); // Deserialize JSON array
        }

        throw new Exception($"Failed to fetch timesheets: {response.StatusCode} {response.ReasonPhrase}");
    }
    public async Task<JArray> GetAllActivities()
    {
        var url = $"{BaseUrl}/timesheets/activities";
        var response = await _client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JArray.Parse(content); // Deserialize JSON array
        }

        throw new Exception($"Failed to fetch activities: {response.StatusCode} {response.ReasonPhrase}");
    }


}

