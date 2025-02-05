using System.Text.Json;
using AssetsManagement.Models;
using Microsoft.JSInterop;

namespace AssetsManagementBlazor.Components.Pages
{
    public partial class Functionalities
    {
        List<Machines> machines = new List<Machines>();
        List<Assets> assets = new List<Assets>();
        Machines? selectedMachine;
        bool IsModalVisible = false;
        bool isDropdownVisible = false;
        protected override async Task OnInitializedAsync()
        {
            if (inMemoryStorageService.GetMachines() == null)
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
                        inMemoryStorageService.SetMachines(machines);
                    }
                }
                Console.WriteLine($"Machines Count: {inMemoryStorageService.GetMachines().Count}");
                Console.WriteLine(machinesResponse);
            }
            else
            {
                machines = inMemoryStorageService.GetMachines();
                
            }

            if (inMemoryStorageService.GetAssets() == null)
            {
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
                        inMemoryStorageService.SetAssets(assets);
                    }
                }

                Console.WriteLine($"Assets Count: {inMemoryStorageService.GetAssets().Count}");
                Console.WriteLine(assetsResponse);
            }
            else
            {
                assets = inMemoryStorageService.GetAssets();
            }
        }

        public void SelectMachine(string machineName)
        {
            //Console.WriteLine(machineName);
            isDropdownVisible = !isDropdownVisible;
            selectedMachine = machines.Find(machine => machine.Name == machineName);
            Console.WriteLine(selectedMachine.Name);
        }

        public void DisplayAssets()
        {
            IsModalVisible = true;
        }
        public void CloseModal()
        {
            IsModalVisible = false;
        }
        public void ToggleDropdown()
        {
            isDropdownVisible = !isDropdownVisible;
        }
    }
}
