using CarAppDotNetApi.Controllers.BaseController;
using CarAppDotNetApi.Dtos;
using CarAppDotNetApi.Security;
using CarAppDotNetApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarAppDotNetApi.Controllers
{    
    [ApiController]
    [Route("Admin")]
    public class AdminController: BaseCarAppController
    {
        private readonly ICarService _carService;
        
        public AdminController(ICarService carService)
        {
            _carService = carService;
        }
        
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route("AddModel")]
        public IActionResult AddModel([FromBody] ModelDto modelDto)
        {
            _carService.AddModel(modelDto);
            return Created(HttpContext.Request.Path, modelDto);
        }
        
    }
}