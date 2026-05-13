using DataVance.Application.Security.Commands;
using DataVance.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace DataVance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(IMediator mediator, SignInManager<ApplicationUser> signInManager)
        {
            _mediator = mediator;
            _signInManager = signInManager;
        }
        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return LocalRedirect("/account/login");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] string email, [FromForm] string password, [FromForm] Guid branchId)
        {
            var command = new LoginCommand(email, password, branchId);
            var success = await _mediator.Send(command);

            if (success)
            {
                return LocalRedirect("/");
            }

            return Redirect("/account/login?error=invalid");
        }

    }

}
