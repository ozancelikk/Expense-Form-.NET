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
    public class VouncherImageController : Controller
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;
        public VouncherImageController(IImageService imageService,IMapper mapper)
        {
            _imageService= imageService;
            _mapper= mapper;
        }
        [HttpPost("AddImage")]
        public IActionResult Add([FromForm(Name = "Image")] IFormFile file, [FromForm] UploadFileDto uploadfiledto)
        {
            var image = _mapper.Map<UploadFile>(uploadfiledto);
            var result = _imageService.Add(file, image);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
        [HttpGet("GetByImagesByVouncherId")]
        public IActionResult GetByImagesByVouncherId(string id)
        {
            var result = _imageService.GetByImagesByVouncherId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
