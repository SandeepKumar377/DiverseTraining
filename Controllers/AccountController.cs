using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiverseTraining.DTOs;
using DiverseTraining.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DiverseTraining.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        //User Registration endpoint
        [HttpPost("Register")]
        public async Task<ActionResult<UserRegisterDto>> Register(UserRegisterDto userRegisterDto)
        {
            //check user is already exist or not
            if (await _accountService.UserExists(userRegisterDto.Email))
            {
                return BadRequest("User already exist");
            }
            var user = await _accountService.SignUp(userRegisterDto);
            // return Ok();
            return Created("~/api/account/register", new { userRegisterDto.Name });
        }
    }
}