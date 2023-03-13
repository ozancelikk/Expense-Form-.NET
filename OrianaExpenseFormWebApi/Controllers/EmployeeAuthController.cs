using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAuthController : Controller
    {
        private IEmployeeAuthService _employeeAuthService;
        public EmployeeAuthController(IEmployeeAuthService employeeAuthService)
        {
            _employeeAuthService = employeeAuthService;     
        }
        [HttpPost("login")]
        public IActionResult Login(EmployeeForLoginDto employeeForLoginDto)
        {
            var employeeToLogin = _employeeAuthService.Login(employeeForLoginDto);
            if (!employeeToLogin.Success)
            {
                return BadRequest(employeeToLogin);
            }

            var result = _employeeAuthService.CreateAccessToken(employeeToLogin.Data);
            if (result.Success)
            {
                result.Data.EmployeeId = employeeToLogin.Data.Id;
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Register")]
        public ActionResult Register(EmployeeForRegisterDto employeeForRegisterDto)
        {
            var userExists = _employeeAuthService.EmployeeExists(employeeForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists);
            }

            var registerResult = _employeeAuthService.Register(employeeForRegisterDto);
            var result = _employeeAuthService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
