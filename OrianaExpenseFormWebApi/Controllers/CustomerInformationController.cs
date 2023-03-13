using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInformationController : Controller
    {
        private ICustomerInformationService _customerInformationService;
        private IMapper _mapper;
        public CustomerInformationController(ICustomerInformationService customerInformationService,IMapper mapper)
        {
            _mapper = mapper;
            _customerInformationService = customerInformationService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerInformationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var result = _customerInformationService.Get();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(CustomerInformationDto customerInformationDto)
        {
            var customerInformation = _mapper.Map<CustomerInformation>(customerInformationDto);
            var result = _customerInformationService.Add(customerInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CustomerInformation customerInformation)
        {
            var result = _customerInformationService.Update(customerInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _customerInformationService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
