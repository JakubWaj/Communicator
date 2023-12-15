using Application.DTO;
using Application.Exceptions;
using Application.Queries.User.GetUserByEmail;
using Domain.Repository;
using MediatR;

namespace Application.Queries.User.GetUserByUsername;

public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery,UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByUsernameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByUsernameAsync(request.Username);
        if (user is null)
        {
            throw new NotFoundException();
        }
        return user.AsDto();
    }
}