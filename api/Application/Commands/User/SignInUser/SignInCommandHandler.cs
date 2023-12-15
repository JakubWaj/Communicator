using Application.Abstraction;
using Application.Security;
using Domain.Repository;
using Domain.Shared;

namespace Application.Commands.User.SignInUser;

public class SignInCommandHandler : ICommandHandler<SignInCommand>
{
    private readonly IPasswordManager _passwordManager;
    private readonly IAuthenticator _authenticator;
    private readonly ITokenStorage _tokenManager;
    private readonly IUserRepository _userRepository;

    public SignInCommandHandler(IPasswordManager passwordManager,IAuthenticator authenticator, ITokenStorage tokenManager, IUserRepository userRepository)
    {
        _passwordManager = passwordManager;
        _authenticator = authenticator;
        _tokenManager = tokenManager;
        _userRepository = userRepository;
    }
    public async Task<Result> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
        {
            return Result.Failure(new Error("400", "Invalid credentials"));
        }
        if(_passwordManager.Validate(request.Password, user.Password))
        {
            var jwt = _authenticator.CreateToken(user.Id);
            _tokenManager.Set(jwt);
            return Result.Success();
        }
        return Result.Failure(new Error("400", "Invalid credentials"));
    }
}