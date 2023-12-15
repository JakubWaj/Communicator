using Application.DTO;
using Application.Exceptions;
using Domain.Repository;
using Domain.Shared;
using MediatR;

namespace Application.Queries.User.GetUserByEmail;

public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery,UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user =await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
        {
            throw new NotFoundException();
        }
        return user.AsDto();
    }
}