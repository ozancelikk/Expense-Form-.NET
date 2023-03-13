using AutoMapper;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginActivitiesController : Controller
    {
        private ILoginActivitiesService _loginActivitiesService;
        public LoginActivitiesController(ILoginActivitiesService loginActivitiesService)
        {
  
            _loginActivitiesService = loginActivitiesService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _loginActivitiesService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = _loginActivitiesService.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
 
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _loginActivitiesService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {

            var deletedDevice = _loginActivitiesService.GetById(id);
            var result = _loginActivitiesService.Delete(deletedDevice.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
