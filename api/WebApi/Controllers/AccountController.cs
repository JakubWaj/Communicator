using Application.Commands.User.SignInUser;
using Application.Commands.User.SignUpUser;
using Application.DTO;
using Application.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenStorage _tokenStorage;
    public AccountController(IMediator mediator, ITokenStorage tokenStorage)
    {
        _mediator = mediator;
        _tokenStorage = tokenStorage;
    }
    
    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpPost("signin")]
    public async Task<ActionResult<JwtDto>> SignIn([FromBody] SignInCommand command)
    {
        await _mediator.Send(command);
        var jwt = _tokenStorage.Get();
        return jwt;
    }
}