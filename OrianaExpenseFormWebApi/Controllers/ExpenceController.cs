using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenceController : Controller
    {
        private readonly IExpenceService _expenceService;
        private readonly IMapper _mapper;
        public ExpenceController(IExpenceService expenceService, IMapper mapper)
        {
            _expenceService = expenceService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public IActionResult Add(ExpenceDto expenceDto)
        {
            var expence = _mapper.Map<Expence>(expenceDto);
            var result = _expenceService.Add(expence);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _expenceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _expenceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }

        [HttpGet("GetByEmployeeId")]
        public IActionResult GetByEmployeeId(string id)
        {
            var result = _expenceService.GetByEmployeeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _expenceService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Expence expence)
        {
            var result = _expenceService.Update(expence);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
