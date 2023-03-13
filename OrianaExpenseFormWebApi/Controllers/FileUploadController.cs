using AutoMapper;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Threading.Tasks;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherImagesController : ControllerBase
    {
        IVoucherImageService _voucherImageService;
        private readonly IMapper _mapper;
        public VoucherImagesController(IVoucherImageService voucherImageService)
        {
            _voucherImageService = voucherImageService;
        }
        [HttpPost("Add")]
        public IActionResult Add(IFormFile file, string voucherId,UploadFileDto uploadFileDto)
        {
            var vouncherImage = _mapper.Map<UploadFile>(uploadFileDto);
            var result = _voucherImageService.Add(file, voucherId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _voucherImageService.Delete(id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(string id, [FromForm] IFormFile file)
        {
            var result = _voucherImageService.Update(file, id);
            if (!result.Success) return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _voucherImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByImageId")]
        public IActionResult GetByImageId(string imageId)
        {
            var result = _voucherImageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
