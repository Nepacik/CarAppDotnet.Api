using System.Collections.Generic;
using CarAppDotNetApi.Models;

namespace CarAppDotNetApi.Repositories
{
    public interface ICarRepository
    {
        public Car FindCarById(int id);

        public List<Car> FindAllCars(int page, int itemsPerPage);
    }
}