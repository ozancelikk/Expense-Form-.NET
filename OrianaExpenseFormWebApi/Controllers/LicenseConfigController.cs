using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseConfigController : Controller
    {
        ILicenseConfigService _licenseConfigService;
        IMapper _mapper;
        public LicenseConfigController(ILicenseConfigService licenseConfigService,IMapper mapper)
        {
            _mapper = mapper;
            _licenseConfigService = licenseConfigService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _licenseConfigService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = _licenseConfigService.Get();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Add")]
        public IActionResult Add(LicenseConfigDto licenseConfigDto)
        {
            var licenseConfig = _mapper.Map<LicenseConfig>(licenseConfigDto);
            var result = _licenseConfigService.Add(licenseConfig);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _licenseConfigService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Update")]
        public IActionResult Update(LicenseConfig licenseConfig)
        {
            var result = _licenseConfigService.Update(licenseConfig);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var deleteDevice = _licenseConfigService.GetById(id);
            var result = _licenseConfigService.Delete(deleteDevice.Data);


            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }
    }
}
