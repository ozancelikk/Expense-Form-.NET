using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeStampConfigController : Controller
    {
        private ITimeStampConfigService _timeStampConfigService;
        private IMapper _mapper;
        public TimeStampConfigController(ITimeStampConfigService timeStampConfigService, IMapper mapper)
        {
            _mapper = mapper;
          _timeStampConfigService = timeStampConfigService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _timeStampConfigService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = _timeStampConfigService.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(TimeStampConfigDto timeStampConfigDto)
        {
            var timeStampConfig = _mapper.Map<TimeStampConfig>(timeStampConfigDto);

            var result = _timeStampConfigService.Add(timeStampConfig);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(TimeStampConfig deviceParser)
        {
            var result = _timeStampConfigService.Update(deviceParser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _timeStampConfigService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
       
            var deletedDevice = _timeStampConfigService.GetById(id);
            var result = _timeStampConfigService.Delete(deletedDevice.Data);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
