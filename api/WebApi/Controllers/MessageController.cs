using Application.Commands.Message.SendMessage;
using Application.Queries.Message.GetByGroupId;
using Application.Queries.Message.GetById;
using Application.Security;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITokenStorage _tokenStorage;

    public MessageController(IMediator mediator, ITokenStorage tokenStorage)
    {
        _mediator = mediator;
        _tokenStorage = tokenStorage;
    }
    
    [HttpPost("send")]
    public async Task<IActionResult> SendMessage(SendMessageCommand command)
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
    
    [HttpGet("{messageId:guid}")]
    public async Task<IActionResult> GetMessages(Guid messageId)
    {
        GetByIdQuery query = new(){Id = messageId};
        var messages = await _mediator.Send(query);
        return Ok(messages);
    }
    
    [HttpGet("group/{groupId:guid}")]
    public async Task<IActionResult> GetMessagesByGroup(Guid groupId)
    {
        GetByGroupIdQuery query = new(){GroupId = groupId};
        var messages = await _mediator.Send(query);
        return Ok(messages);
    }
}