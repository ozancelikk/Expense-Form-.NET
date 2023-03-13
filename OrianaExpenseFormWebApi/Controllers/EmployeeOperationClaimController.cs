using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrianaExpenseFormWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeOperationClaimController : ControllerBase
    {
        IEmployeeOperationClaimService _employeeOperationClaimService;
        public EmployeeOperationClaimController(IEmployeeOperationClaimService employeeOperationClaimService)
        {
                _employeeOperationClaimService= employeeOperationClaimService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var claims = _employeeOperationClaimService.GetAllClaims();
            if (claims.Success)
            {
                return Ok(claims);
            }
            return BadRequest(claims);
        }
        [HttpPost("EmployeeAuthorization")]
        public IActionResult EmployeeAuthorization(EmployeeOperationClaimDto employeeOperationClaimSimple) {
            var result = _employeeOperationClaimService.Add(employeeOperationClaimSimple);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Delete(EmployeeOperationClaim employeeOperationClaim)
        {
            var result = _employeeOperationClaimService.Update(employeeOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var employeeOperationClaims = _employeeOperationClaimService.GetById(id);
            EmployeeOperationClaim employeeOperationClaim = new EmployeeOperationClaim { Id = employeeOperationClaims.Data.Id, EmployeeId = employeeOperationClaims.Data.EmployeeId, OperationClaimId = employeeOperationClaims.Data.OperationClaimId };
            var result = _employeeOperationClaimService.Delete(employeeOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _employeeOperationClaimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }    
}
