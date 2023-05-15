using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : Controller
    {
        private readonly IVoucherService _vouncherService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public VoucherController(IVoucherService voucherService,IMapper mapper,IWebHostEnvironment environment)
        {
            _mapper = mapper;
            _vouncherService = voucherService;
            _webHostEnvironment = environment;
        }
        [HttpPost("Add")]
        public IActionResult Add(VouncherDto vouncherDto)
        {
           var vouncher = _mapper.Map<Vouncher>(vouncherDto);
           var result =  _vouncherService.Add(vouncher);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("VouncherGetDto")]
        public IActionResult VouncherGetDto()
        {
            var result = _vouncherService.VouncherGetDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _vouncherService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _vouncherService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByVouncherId")]
        public IActionResult GetByVouncherId(string id)
        {
            var result = _vouncherService.GetByVouncherId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByEmployeeId")]
        public IActionResult GetByEmployeeId(string id)
        {
            var result = _vouncherService.GetByEmployeeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetDetailsByEmployeeId")]
        public IActionResult GetDetailsByEmployeeId(string id)
        {
            var result = _vouncherService.GetDetailsByEmployeeId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByExpenceId")]
        public IActionResult GetByExpenceId(string id)
        {
            var result = _vouncherService.GetByExpenceId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _vouncherService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Vouncher vouncher)
        {
            var result = _vouncherService.Update(vouncher);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("UploadImage")]
        public async Task<ActionResult> UploadImage()
        {
            bool result = false;
            try
            {
                var _uploadFiles = Request.Form.Files;
                foreach (IFormFile source in _uploadFiles) { 
                    string FileName=source.FileName;
                    string FilePath = GetFilePath(FileName);
                    if (!System.IO.Directory.Exists(FilePath))
                    {
                        System.IO.Directory.CreateDirectory(FilePath);
                    }

                    string imagePath = FilePath + "\\image.png";

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath); 
                    }

                    using (FileStream stream=System.IO.File.Create(imagePath))
                    {
                        await source.CopyToAsync(stream);
                        result=true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return Ok(result);
        }

        private string GetFilePath(string vouncherCode)
        {
            return this._webHostEnvironment.WebRootPath + "\\Uploads\\Vouncher" + vouncherCode;
        }
        [NonAction]
        private string GetImagebyProduct(string vounchercode)
        {
            string ImageUrl = string.Empty;
            string HostUrl = "https://localhost:4200/";
            string Filepath = GetFilePath(vounchercode);
            string Imagepath = Filepath + "\\image.png";
            if (!System.IO.File.Exists(Imagepath))
            {
                ImageUrl = HostUrl + "/Uploads/Common/noimage.png";
            }
            else
            {
                ImageUrl = HostUrl + "/uploads/Product/" + vounchercode + "/image.png";
            }
            return ImageUrl;

        }
    }
}
