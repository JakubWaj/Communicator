using Domain.Shared;
using MediatR;

namespace Application.Abstraction;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand,Result> where TCommand : ICommand
{
    
}

public interface ICommandHandler<TCommand,TResponse> : IRequestHandler<TCommand,Result<TResponse>> where TCommand : ICommand<TResponse>
{
    
}