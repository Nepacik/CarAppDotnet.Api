using System.Collections.Generic;
using System.Linq;
using CarAppDotNetApi.Data;
using CarAppDotNetApi.Models;
using CarAppDotNetApi.Repositories.BaseRepositories;
using Microsoft.EntityFrameworkCore;

namespace CarAppDotNetApi.Repositories.implementation
{
    public class CarRepositoryImpl : BaseRepository<Car>, ICarRepository
    {
        public CarRepositoryImpl(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Car FindCarById(int id)
        {
            return _dbSet
                .Include(e => e.Model)
                .SingleOrDefault(e => e.Id == id);
        }

        public List<Car> FindAllCars(int page, int itemsPerPage)
        {
            return _dbSet.Include(e => e.Model)
                .OrderBy(car => car.Id)
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();
        }
    }
}