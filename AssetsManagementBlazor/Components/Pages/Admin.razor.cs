using static System.Net.WebRequestMethods;

namespace AssetsManagementBlazor.Components.Pages
{
    public partial class Admin
    {
        string textMessage = string.Empty;
        string jsonMessage = string.Empty;
        string text = "text";
        string json = "json";
        public async Task AddDataAsync(string dataFormat)
        {
            Console.WriteLine("heyy");
            if(dataFormat.Equals(text))
            {
                var content = new StringContent(""); 
                var response = await Http.PostAsync("https://localhost:7101/api/admin/text", content);
                if (response.IsSuccessStatusCode)
                {
                    textMessage = "Data added Successfully.";
                }
                else
                {
                    textMessage = "Something went wrong, Try again...";
                }
            }
            else
            {
                var content = new StringContent(""); 
                var response = await Http.PostAsync("https://localhost:7101/api/admin/json", content);
                Console.WriteLine(response);
                if (response.IsSuccessStatusCode)
                {
                    jsonMessage = "Data added Successfully.";
                }
                else
                {
                    jsonMessage = "Something went wrong, Try again...";
                }
            }
        }
        
    }
}
