using ClientRegister.API.Core.Interfaces;
using ClientRegister.Support.Models;
using ClientRegister.Support.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClientRegister.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBusiness _authBusiness;

        public AuthController(IAuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Post(AuthUserDto userDto)
        {
            try
            {
                var response = _authBusiness.LoginUser(userDto);
                if (!(response.Succeeded))
                {
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                var listErrors = new string[1];
                listErrors[0] = e.Message;
                return StatusCode(500, new Response<AuthUserDto>(
                    data: null, succeeded: false, errors: listErrors, message: "Internal server error"));
            }
        }
    }
}
