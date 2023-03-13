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
    public class UploadReceiptImageController : Controller
    {
        private readonly IUploadReceiptImageService _uploadReceiptImageService;
        private readonly IMapper _mapper;
        public UploadReceiptImageController(IUploadReceiptImageService uploadReceiptImageService, IMapper mapper)
        {
            _uploadReceiptImageService = uploadReceiptImageService;
            _mapper = mapper;
        }
        [HttpPost("AddImage")]
        public IActionResult Add([FromForm(Name ="Image")] IFormFile file, [FromForm] UploadReceiptImageDto uploadReceiptImageDto)
        {
            var image = _mapper.Map<UploadReceiptImage>(uploadReceiptImageDto);
            var result=_uploadReceiptImageService.Add(file,image);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("GetImagesByReceiptId")]
        public IActionResult GetImagesByReeciptId(string id)
        {
            var result =_uploadReceiptImageService.GetByImagesByReceiptId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
