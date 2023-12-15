using Domain.Shared;
using MediatR;

namespace Application.Abstraction;

public interface ICommand : IRequest<Result>
{
    
}

public interface ICommand<TResult> : IRequest<Result<TResult>>
{
    
}

