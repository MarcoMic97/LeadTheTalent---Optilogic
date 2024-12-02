
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var kimaiClient = new KimaiClient();
        var activities = await kimaiClient.GetAllActivities();
        Console.WriteLine("Available Activities:");
        foreach (var activity in activities)
        {
            Console.WriteLine($"ID: {activity["id"]}, Name: {activity["name"]}");
        }
        /*

            var kimaiClient = new KimaiClient();

            try
            {
                // Define the activity name
                string activityName = "100-Timer Normal";

                // Get the activity ID
                var activityId = await kimaiClient.FetchTimesheetsByActivityId(activityName);
                if (activityId == null)
                {
                    Console.WriteLine($"Activity '{activityName}' not found.");
                    return;
                }

                Console.WriteLine($"Activity ID for '{activityName}': {activityId}");

                // Fetch timesheets for the activity (without date filters)
                var timesheets = await kimaiClient.FetchTimesheetsByActivityId(activityName);

                // Display fetched timesheets
                Console.WriteLine("Fetched Timesheets:");
                foreach (var entry in timesheets)
                {
                    Console.WriteLine($"ID: {entry["id"]}, Begin: {entry["begin"]}, End: {entry["end"]}, Description: {entry["description"]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }*/
    }
}
