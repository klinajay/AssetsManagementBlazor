using System.Text.Json;
using AssetsManagement.Models;
using Microsoft.JSInterop;

namespace AssetsManagementBlazor.Components.Pages
{
    public partial class Functionalities
    {
        List<Machines> machines = new List<Machines>();
        List<Assets> assets = new List<Assets>();

        protected override async Task OnInitializedAsync()
        {
           
                var machinesResponse = await Http.GetAsync("https://localhost:7101/api/machines");
                if (machinesResponse.IsSuccessStatusCode)
                {
                    var responseBody = await machinesResponse.Content.ReadAsStringAsync();
                    var jsonResponse = JsonSerializer.Deserialize<List<Machines>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (jsonResponse != null)
                    {
                        machines = jsonResponse;
                 
                    }
                }
           
                Console.WriteLine(machinesResponse);
           

         
                var assetsResponse = await Http.GetAsync("https://localhost:7101/api/assets");
                if (assetsResponse.IsSuccessStatusCode)
                {
                    var responseBody = await assetsResponse.Content.ReadAsStringAsync();
                    var jsonResponse = JsonSerializer.Deserialize<List<Assets>>(responseBody, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (jsonResponse != null)
                    {
                        assets = jsonResponse;
                      
                    }
                }

                Console.WriteLine($"Assets Count: {assets.Count}");
           
        }

     
      
    }
}
