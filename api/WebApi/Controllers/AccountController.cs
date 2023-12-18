using Application.Commands.User.SignInUser;
using Application.Commands.User.SignUpUser;
using Application.DTO;
using Application.Queries.User.GetAllUsers;
using Application.Queries.User.GetUserByEmail;
using Application.Queries.User.GetUserByGuid;
using Application.Queries.User.GetUserByUsername;
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
        Guid guid = Guid.NewGuid();
        await _mediator.Send(command with{UserId = guid});
        return CreatedAtAction(nameof(Get), new {guid}, null);
    }
    
    [HttpPost("signin")]
    public async Task<ActionResult<JwtDto>> SignIn([FromBody] SignInCommand command)
    {
        await _mediator.Send(command);
        var jwt = _tokenStorage.Get();
        return jwt;
    }
    
    [HttpGet("me")]
    public async  Task<ActionResult<UserDto>> Get()
    {
        if(User.Identity?.Name is null)
        {
            return NotFound();
        }
        
        var guid = Guid.Parse(User.Identity?.Name);
        var user = await _mediator.Send(new GetUserByIdQuery(){Id = guid});
        return Ok(user);
    }
    
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<UserDto>> Get(Guid userId)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(){Id = userId});
        return Ok(user);
    }
    
    [HttpGet("username/{username}")]
    public async Task<ActionResult<UserDto>> Get(string username)
    {
        var user = await _mediator.Send(new GetUserByUsernameQuery(){Username = username});
        return Ok(user);
    }
    
    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserDto>> GetByEmail(string email)
    {
        var user = await _mediator.Send(new GetUserByEmailQuery(){Email = email});
        return Ok(user);
    }
    
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }
    
}