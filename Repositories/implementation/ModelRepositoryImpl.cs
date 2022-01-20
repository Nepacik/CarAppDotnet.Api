using System.Linq;
using System.Net;
using CarAppDotNetApi.Data;
using CarAppDotNetApi.ErrorHandling;
using CarAppDotNetApi.Models;
using CarAppDotNetApi.Repositories.BaseRepositories;

namespace CarAppDotNetApi.Repositories.implementation
{
    public class ModelRepositoryImpl: BaseRepository<Model>,  IModelRepository
    {

        public ModelRepositoryImpl(AppDbContext appDbContext) : base(appDbContext)
        {
            
        }
        public void AddModel(Model model)
        {
            if (GetModelByName(model.Name) != null)
            {
                throw new AppException(HttpStatusCode.Conflict, "MODEL_ALREADY_EXISTS");
            }
            _dbSet.Add(model);
            SaveChanges();
        }

        public Model GetModelByName(string name)
        {
            return _dbSet.SingleOrDefault(model => model.Name == name);
        }
    }
}