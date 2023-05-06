using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace Player_Investigator
{
    public class GetPlayerSummaryObject
    {
        
    }

    internal class Queryer
    {
        //Error handling

        //https://developer.valvesoftware.com/wiki/Steam_Web_API
        //https://partner.steamgames.com/doc/webapi_overview
        //https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
        //https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-return-types
        //https://api.steampowered.com/<interface>/<method>/v<version>/

        //https://learn.microsoft.com/en-us/samples/dotnet/samples/windowsforms-formatting-utility-cs/
        //https://stackoverflow.com/questions/61497025/c-sharp-iterate-over-a-json-object
        //https://www.epochconverter.com/

        //GetPlayerSummaries
        //GetFriendList?
        //GetPlayerAchievements/GetUserStatsForGame?
        //GetOwnedGames/GetRecentlyPlayedGames

        private HttpClient httpClient;

        public string output;

        //Form functions

        public Queryer()
        {
            output = "";
            httpClient = new()
            {
                BaseAddress = new Uri("https://api.steampowered.com"),
                //BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
            };
        }

        //Other functions

        public async Task GetAsync()
        {
            using HttpResponseMessage response = await httpClient.GetAsync("todos/3");

            response.EnsureSuccessStatusCode();
            WriteRequestToOutput(response);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            output += jsonResponse;
            //richTextBox1.Text = ($"{jsonResponse}\n");
        }

        public async Task GetAll()
        {
            await GetPlayerSummary();
        }

        public async Task GetPlayerSummary()
        {
            using HttpResponseMessage response = await httpClient.GetAsync("ISteamUser/GetPlayerSummaries/v0002/?key=4DA0CD7EC93E4167D233CCF091DD4B8F&steamids=76561197960435530");

            response.EnsureSuccessStatusCode();
            WriteRequestToOutput(response);

            var jsonResponse = await response.Content.ReadAsStringAsync();

            jsonResponse = jsonResponse.Substring(24);
            jsonResponse = jsonResponse.Replace("]}}", "");

            var playerDictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonResponse);

            foreach (var item in playerDictionary)
            {
                //item.Value = ToString();
            }

            output += jsonResponse;
        }

        private void WriteRequestToOutput(HttpResponseMessage response)
        {
            if (response is null)
            {
                return;
            }

            var request = response.RequestMessage;
            //string output = "";
            output += ($"{request?.Method} ");
            output += ($"{request?.RequestUri} ");
            output += ($"HTTP/{request?.Version}\n");
        }
    }
}