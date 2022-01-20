using CarAppDotNetApi.ErrorHandling;
using Microsoft.AspNetCore.Mvc;

namespace CarAppDotNetApi.Controllers.BaseController
{
    public class BaseCarAppController: ControllerBase
    {
        protected IActionResult BaseGetResult(object content)
        {
            if (content == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(content);
            }
        }
    }
}