using System.Net.Http.Headers;
using System.Text;


namespace Optilogic
{
    class Program
    {
        static void Main(string[] args)
        {
            // Replace with your Kimai instance URL
            string kimaiUrl = "https://your-kimai-instance.com";

            // Replace with your Kimai username and password
            string username = "your-username";
            string password = "your-password";

            // Authenticate and obtain an API token
            string authToken = GetAuthToken(kimaiUrl, username, password);

            // Retrieve a list of time entries
            TimeEntry[] timeEntries = GetTimeEntries(kimaiUrl, authToken);

            // Print the list of time entries
            foreach (TimeEntry timeEntry in timeEntries)
            {
                Console.WriteLine($"ID: {timeEntry.Id}, Start: {timeEntry.Start}, End: {timeEntry.End}");
            }
        }

        static string GetAuthToken(string kimaiUrl, string username, string password)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(kimaiUrl);

                // Set the authentication headers
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}")));

                // Make the authentication request
                HttpResponseMessage response = client.PostAsync("api/auth/token", null).Result;

                // Check the response status code
                if (response.IsSuccessStatusCode)
                {
                    // Get the API token from the response
                    string authToken = response.Content.ReadAsStringAsync().Result;
                    return authToken;
                }
                else
                {
                    throw new Exception("Failed to authenticate");
                }
            }
        }

        static TimeEntry[] GetTimeEntries(string kimaiUrl, string authToken)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(kimaiUrl);

                // Set the API token header
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                // Make the request to retrieve time entries
                HttpResponseMessage response = client.GetAsync("api/time-entries").Result;

                // Check the response status code
                if (response.IsSuccessStatusCode)
                {
                    // Get the time entries from the response
                    string timeEntriesJson = response.Content.ReadAsStringAsync().Result;
                    TimeEntry[] timeEntries = JsonConvert.DeserializeObject<TimeEntry[]>(timeEntriesJson);
                    return timeEntries;
                }
                else
                {
                    throw new Exception("Failed to retrieve time entries");
                }
            }
        }
    }

    public class TimeEntry
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}