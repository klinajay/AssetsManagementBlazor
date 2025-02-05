using static System.Net.WebRequestMethods;

namespace AssetsManagementBlazor.Components.Pages
{
    public partial class Admin
    {
        string message = string.Empty;
        public async Task AddDataAsync()
        {
            Console.WriteLine("heyy");
            var content = new StringContent(""); // Empty content
            var response = await Http.PostAsync("http://restapi:8080/api/admin", content);
            Console.WriteLine(response);
            Console.WriteLine(response);
            if(response.IsSuccessStatusCode)
            {
                message = "Data added Successfully.";
            }
            else
            {
                message = "Something went wrong, Try again...";
            }
        }
    }
}
