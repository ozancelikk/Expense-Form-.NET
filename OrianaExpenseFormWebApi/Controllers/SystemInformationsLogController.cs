using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemInformationsLogController : Controller
    {
        ISystemInformationsLogService _systemInformationsLogService;
        public SystemInformationsLogController(ISystemInformationsLogService systemInformationsLogService)
        {
            _systemInformationsLogService = systemInformationsLogService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _systemInformationsLogService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
   

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _systemInformationsLogService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var deleteDevice = _systemInformationsLogService.GetById(id);
            var result = _systemInformationsLogService.Delete(deleteDevice.Data);


            if (result.Success)
            {

                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("GetAllUnReadMessageByStatus")]
        public IActionResult GetAllUnReadMessageByStatus()
        {
            var result = _systemInformationsLogService.GetAllUnReadMessageByStatus();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("UpdateAllUnReadMessageById")]
        public IActionResult UpdateAllUnReadMessageById(string[] id)
        {
            var result = _systemInformationsLogService.UpdateAllUnReadMessageById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("UpdateAllUnReadMessage")]
        public IActionResult UpdateAllUnReadMessage()
        {
            var result = _systemInformationsLogService.UpdateAllUnReadMessage();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("UpdateUnReadMessage")]
        public IActionResult UpdateUnReadMessage(string id)
        {
            var result = _systemInformationsLogService.UpdateUnreadMessage(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAllUnReadMessageWithPage")]
        public IActionResult GetAllUnReadMessageWithPage(int page, int limit)
        {
            var result = _systemInformationsLogService.GetAllUnReadMessageWithPage(page, limit);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
