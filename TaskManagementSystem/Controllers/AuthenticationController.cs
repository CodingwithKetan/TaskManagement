using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace TaskManagementSystem.API.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] EmployeeRegistrationDto employeeRegistrationDto)
        {
            var result = await _authenticationService.RegisterUser(employeeRegistrationDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] EmployeeAuthenticationDto user)
        {
            if (!await _authenticationService.ValidateUser(user))
                return new UnauthorizedResult();

            return Ok(new
            {
                Token = await _authenticationService.CreateToken()
            });
        }
    }
}
