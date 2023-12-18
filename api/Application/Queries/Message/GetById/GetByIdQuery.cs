using Application.DTO;
using MediatR;

namespace Application.Queries.Message.GetById;

public class GetByIdQuery : IRequest<MessageDto>
{
    public Guid Id { get; set; }
}