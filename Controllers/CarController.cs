using CarAppDotNetApi.Controllers.BaseController;
using CarAppDotNetApi.Security;
using CarAppDotNetApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarAppDotNetApi.Controllers
{
    [ApiController]
    [Route("Car")]
    public class CarController : BaseCarAppController
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [Authorize(Roles = Role.User + "," + Role.Admin)]
        [HttpGet("{id:int}")]
        public IActionResult GetCarById(int id)
        {
            return BaseGetResult(_carService.FindCarById(id));
        }
        
        [Authorize(Roles = Role.User + "," + Role.Admin)]
        [HttpGet("GetAllCars/{page:int}")]
        public IActionResult GetAllCars(int page)
        {
            return Ok(_carService.FindAllCars(page));
        }
    }

}