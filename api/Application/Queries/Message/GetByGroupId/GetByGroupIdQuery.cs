using Application.DTO;
using MediatR;

namespace Application.Queries.Message.GetByGroupId;

public class GetByGroupIdQuery : IRequest<ICollection<MessageDto>>
{
    public Guid GroupId { get; set; }
}