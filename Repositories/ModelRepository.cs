using CarAppDotNetApi.Models;

namespace CarAppDotNetApi.Repositories
{
    public interface IModelRepository
    {
        public void AddModel(Model model);

        public Model GetModelByName(string name);
    }
}