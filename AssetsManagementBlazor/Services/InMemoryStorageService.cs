using AssetsManagement.Models;

namespace AssetsManagementBlazor.Services
{
    public class InMemoryStorageService
    {
        public List<Machines> machines;
        public List<Assets> assets;
        public void SetItems(List<Machines> machines , List<Assets> assets)
        {
            this.machines = machines;
            this.assets = assets;
        }
        public void GetItems(out List<Machines> machines, out List<Assets> assets)
        {
            machines = this.machines;
            assets = this.assets;
        }

        public void SetMachines(List<Machines> machines)
        {
            this.machines = machines;
        }
        public List<Machines> GetMachines()
        {
            return machines;
        }
        public void SetAssets(List<Assets> assets)
        {
            this.assets = assets;
        }
        public List<Assets> GetAssets()
        {
            return assets;
        }
    }
}
