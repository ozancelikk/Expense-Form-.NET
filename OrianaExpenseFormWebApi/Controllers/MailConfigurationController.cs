using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailConfigurationController : Controller
    {
        private IMailConfigService _eMailConfigService;
        private IMapper _mapper;
        public MailConfigurationController(IMailConfigService eMailConfigService,IMapper mapper)
        {
            _mapper = mapper;
            _eMailConfigService = eMailConfigService;
        }
        [HttpPost("Add")]
        public IActionResult Add(MailConfigDto mailConfigDto)
        {
            var mailConfig = _mapper.Map<MailConfig>(mailConfigDto);
            var result = _eMailConfigService.Add(mailConfig);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _eMailConfigService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(MailConfig eMailConfig)
        {
            var result = _eMailConfigService.Update(eMailConfig);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = _eMailConfigService.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _eMailConfigService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var emailConfig = _eMailConfigService.GetById(id);

            if (emailConfig.Data == null)
            {
                return Ok("Böyle bir cihaz bulunamadı");
            }
            var result = _eMailConfigService.Delete(emailConfig.Data);


            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }


    }
}
