using CarAppDotNetApi.Dtos;

namespace CarAppDotNetApi.Services
{
    public interface ICarService
    {
        CarDto FindCarById(int id);
        CarAppPagedModel<CarDto> FindAllCars(int page);
        void AddModel(ModelDto modelDto);
    }
}