using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player_Investigator
{
    internal class Queryer
    {
        //https://developer.valvesoftware.com/wiki/Steam_Web_API
        //https://partner.steamgames.com/doc/webapi_overview
        //https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient
        //https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-return-types
        //https://api.steampowered.com/<interface>/<method>/v<version>/

        private HttpClient httpClient;

        public string output;

        //Form functions

        public Queryer()
        {
            output = "";
            httpClient = new()
            {
                //BaseAddress = new Uri("https://api.steampowered.com"),
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
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