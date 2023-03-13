using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete.Simples;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OrianaWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;
        private IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
              
        var users = _userService.GetAll();
           
       
            if (users.Success)
            {
               return Ok(users);
            }
            return BadRequest(users);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var user = _userService.GetById(id);
            User deleteUser = new User();
            deleteUser.Id = user.Data.Id;
            deleteUser.Email = user.Data.Email;
            deleteUser.FirstName = user.Data.FirstName; 
            deleteUser.LastName = user.Data.LastName;
            deleteUser.Status = user.Data.Status;
           
            
            var result = _userService.Delete(deleteUser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("Update")]
        public IActionResult Update(UserDto userSimple)
        {
          
            var result = _userService.Update(userSimple);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetClaims")]
        public IActionResult GetClaims(string id)
        {

            var user = _userService.GetById(id);
            User userClaim= new User();
            userClaim.Id = user.Data.Id;
            userClaim.Email = user.Data.Email;
            userClaim.FirstName = user.Data.FirstName;
            userClaim.LastName = user.Data.LastName;
            userClaim.Status = user.Data.Status;
            var claims = _userService.GetClaims(userClaim);


            if (claims.Success)
            {
                return Ok(claims);
            }
            return BadRequest(claims);
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(UserForChangePasswordDto userForChangePasswordDto)
        {
         
            var result = _userService.ChangePassword(userForChangePasswordDto);


            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _userService.GetById(id);
            var user = new UserDto { Email = result.Data.Email, FirstName = result.Data.FirstName, LastName = result.Data.LastName, Status = result.Data.Status, Id = result.Data.Id };
           
            if (result.Success)
            {
              var results =   new SuccessDataResult<UserDto>(user);
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
