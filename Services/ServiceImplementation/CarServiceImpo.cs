using System.Collections.Generic;
using AutoMapper;
using CarAppDotNetApi.Dtos;
using CarAppDotNetApi.Models;
using CarAppDotNetApi.Repositories;

namespace CarAppDotNetApi.Services.ServiceImplementation
{
    public class CarServiceImpl : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IModelRepository _modelRepository;
        private readonly IMapper _mapper;

        public CarServiceImpl(ICarRepository carRepository, IMapper mapper, IModelRepository modelRepository)
        {
            _carRepository = carRepository;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public CarDto FindCarById(int id)
        {
            var car = _carRepository.FindCarById(id);

            var carDto = _mapper.Map<CarDto>(car);

            return carDto;
        }

        public CarAppPagedModel<CarDto> FindAllCars(int page)
        {
            CarAppPagedModel<CarDto> pagedCars = new CarAppPagedModel<CarDto>(page);
            
            var listOfCars = _carRepository.FindAllCars(pagedCars.Page, pagedCars.ItemsPerPage);
            var listOfCarsDto = _mapper.Map<List<CarDto>>(listOfCars);
            
            pagedCars.Elements = listOfCarsDto;

            return pagedCars;
        }

        public void AddModel(ModelDto modelDto)
        {
            _modelRepository.AddModel(new Model
            {
                Name = modelDto.Name
            });
        }
    }
}