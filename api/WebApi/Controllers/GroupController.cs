using Application.Commands.Group.AddUserToGroup;
using Application.Commands.Group.CreateGroup;
using Application.Queries.Group.GetGroupById;
using Application.Queries.Group.GetGroupsByUser;
using Application.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenStorage _tokenStorage;

    public GroupController(IMediator mediator, ITokenStorage tokenStorage)
    {
        _mediator = mediator;
        _tokenStorage = tokenStorage;
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> CreateGroup(CreateGroupCommand command)
    {
        if(User.Identity?.Name is null)
        {
            return NotFound();
        }
        
        var guid = Guid.Parse(User.Identity?.Name);
        command.UserId = guid;
        await _mediator.Send(command);
        return Ok();
    }
    [HttpPost("adduser")]
    public async Task<IActionResult> AddUserToGroup(AddUserToGroupCommand command)
    {
        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpGet("{groupId:guid}")]
    public async Task<IActionResult> GetGroup(Guid groupId)
    {
        GetGroupByIdQuery query = new(){GroupId = groupId};
        var group = await _mediator.Send(query);
        return Ok(group);
    }
    
    [HttpGet("mygroups")]
    public async Task<IActionResult> GetGroupsByUser()
    {
        if(User.Identity?.Name is null)
        {
            return NotFound();
        }
        GetGroupsByUserQuery query = new();
        var guid = Guid.Parse(User.Identity?.Name);
        query.UserId = guid;
        var group = await _mediator.Send(query);
        return Ok(group);
    }
}