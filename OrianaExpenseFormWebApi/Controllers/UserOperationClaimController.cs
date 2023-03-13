using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.Simples;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrianaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController : Controller
    {
        IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var claims = _userOperationClaimService.GetAllClaims();


            if (claims.Success)
            {
                return Ok(claims);
            }
            return BadRequest(claims);

        }

        [HttpPost("UserAuthorization")]
        public IActionResult UserAuthorization(UserOperationClaimDto userOperationClaimSimple)
        {
           var result = _userOperationClaimService.Add(userOperationClaimSimple);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }
        [HttpPost("Update")]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Update(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var userOperationClaims = _userOperationClaimService.GetById(id);
            UserOperationClaim userOperationClaim = new UserOperationClaim { Id = userOperationClaims.Data.Id, UserId = userOperationClaims.Data.UserId, OperationClaimId = userOperationClaims.Data.OperationClaimId };
            var result = _userOperationClaimService.Delete(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _userOperationClaimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



    }
}
