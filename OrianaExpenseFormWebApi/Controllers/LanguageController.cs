using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace OrianaWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : Controller
    {

        private readonly ILanguageService _langService;

        public LanguageController(ILanguageService langService)
        {
            _langService = langService;
        }

        [HttpGet("SetLanguage")]
        public IActionResult SetLanguage(string language)
        {
            var result =_langService.SetLanguage(language);
            if (result.Success)
            {
               
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
