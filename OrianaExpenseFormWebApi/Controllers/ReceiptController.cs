using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;
        private readonly IMapper _mapper;
        public ReceiptController(IReceiptService receiptService,IMapper mapper)
        {
            _receiptService = receiptService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public IActionResult Add(ReceiptDto receiptDto)
        {
            var receipt = _mapper.Map<Receipt>(receiptDto);
            var result= _receiptService.Add(receipt);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll")]
        public IActionResult Getall() 
        {
            var result=_receiptService.GetAll();
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("ReceiptGetDto")]
        public IActionResult ReceiptGetDto()
        {
            var result=_receiptService.ReceiptGetDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(string id) 
        {
            var result=_receiptService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);  
        }
        [HttpGet("GetAllByEmployeeId")]
        public IActionResult GetAllByemployeeId(string id)
        {
            var result = _receiptService.GetAllByEmployeeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result=_receiptService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Update")]
        public IActionResult Update(Receipt receipt)
        {
            var result = _receiptService.Update(receipt);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
