using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HardwareInformationController : Controller
    {
        private readonly IHardwareInformationService _hardwareInformationService;
        public HardwareInformationController(IHardwareInformationService hardwareInformationService)
        {
                _hardwareInformationService = hardwareInformationService;
        }
        [HttpGet("GetCpuCoreList")]
        public IActionResult GetCpuCoreList()
        {
            var result = _hardwareInformationService.GetCpuCoreList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetCpuCoreListByDate")]
        public IActionResult GetCpuCoreListByDate(string date)
        {
            var result = _hardwareInformationService.GetCpuCoreListByDate(date);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("GetMemoryStatusListByDate")]
        public IActionResult GetMemoryStatusListByDate(string date)
        {
            var result = _hardwareInformationService.GetMemoryStatusListByDate(date);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _hardwareInformationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAllByDate")]
        public IActionResult GetAllByDate(string date)
        {
            var result = _hardwareInformationService.GetAllByDate(date);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
