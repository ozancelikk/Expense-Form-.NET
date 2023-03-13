using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeLoginActivitiesController : Controller
    {
        private IEmployeeLoginActivitiesService _employeeLoginActivities;
        public EmployeeLoginActivitiesController(IEmployeeLoginActivitiesService employeeLoginActivities)
        {
            _employeeLoginActivities = employeeLoginActivities;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _employeeLoginActivities.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result= _employeeLoginActivities.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _employeeLoginActivities.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {

            var deletedDevice = _employeeLoginActivities.GetById(id);
            var result = _employeeLoginActivities.Delete(deletedDevice.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
