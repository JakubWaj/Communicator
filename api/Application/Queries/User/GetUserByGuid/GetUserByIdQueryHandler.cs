﻿using Application.DTO;
using Application.Exceptions;
using Domain.Repository;
using MediatR;

namespace Application.Queries.User.GetUserByGuid;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,UserDto>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user =await _userRepository.GetByIdAsync(request.Id);
        if (user is null)
        {
            throw new NotFoundException();
        }
        return user.AsDto();
    }
}