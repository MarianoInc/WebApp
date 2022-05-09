using ClientRegister.API.Core.Interfaces;
using ClientRegister.Support.Models;
using ClientRegister.Support.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ClientRegister.API.Controllers
{
    [Route("clients")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness _clientBusiness;

        public ClientController(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get(bool clientState)
        {
            try
            {
                var result = await _clientBusiness.GetClientsAsync(clientState);
                if (result == null && clientState == false)
                    return Ok(new Response<string>(null, true, null, "No innactive clients found, yet!"));

                if (result == null)
                    return Ok(new Response<string>(null, true, null, "No clients found, yet!"));

                return Ok(result);
            }
            catch (Exception e)
            {
                var errorList = new string[] { e.Message };
                return StatusCode(500, new Response<string>(null, false, errorList, "Server error"));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                var result = await _clientBusiness.GetClientAsync(id);
                return result.Succeeded == true ? Ok(result) : NotFound(result); 

            }
            catch (Exception e)
            {
                var errorList = new string[] { e.Message };
                return StatusCode(500, new Response<string>(null, false, errorList, "Server error"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(ClientDtoToClient clientDto)
        {
            try
            {
                var result = await _clientBusiness.AddClientAsync(clientDto);
                return result.Succeeded == true ? Ok(result) : BadRequest(result);
            }
            catch (Exception e)
            {
                var errorList = new string[] { e.Message };
                return StatusCode(500, new Response<string>(null, false, errorList, "Server error"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(ClientToClientDto clientDto)
        {
            try
            {
                var result = await _clientBusiness.UpdateClientAsync(clientDto);
                return result.Succeeded == true ? Ok(result) : BadRequest(result);
            }
            catch (Exception e)
            {
                var errorList = new string[] { e.Message };
                return StatusCode(500, new Response<string>(null, false, errorList, "Server error"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _clientBusiness.DeleteClientAsync(id);
                return result.Succeeded == true ? Ok(result) : NotFound(result);
            }
            catch (Exception e)
            {
                var errorList = new string[] { e.Message };
                return StatusCode(500, new Response<string>(null, false, errorList, "Server error"));
            }
        }
    }
}
