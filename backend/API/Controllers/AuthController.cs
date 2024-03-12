using Application.Common.Models.Auth;
using Application.Common.Services.Auth;
using backend.Application.Common.Models;
using Domain.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace API.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(AuthRequest request)
        {
            try
            {
                var response = await _authService.LoginAsync(request);
                return Ok(response);
            }
            catch(UserNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AuthenticationException ex)
            {
                return Unauthorized(ex.Message);
            }

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegistrationRequest request)
        {
            try
            {
                var response = await _authService.RegisterAsync(request);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
