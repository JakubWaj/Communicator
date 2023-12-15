using Application.Abstraction;
using Application.Security;
using Domain.Repository;
using Domain.Shared;
using Domain.ValueObjects.User;

namespace Application.Commands.User.SignUpUser;

public class SignUpCommandHandler : ICommandHandler<SignUpCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordManager _passwordManager;
    public SignUpCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordManager passwordManager)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordManager = passwordManager;
    }
    
    public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
    {
        UserId userId = new(request.UserId);
        Email email = new(request.Email);
        Username username = new(request.Username);
        Password password = new(request.Password);

        if (await _userRepository.GetByIdAsync(userId) is not null)
        {
            return Result.Failure(new Error("400", "User already exists"));
        }
        
        if (await _userRepository.GetByEmailAsync(email) is not null)
        {
            return Result.Failure(new Error("400", "Email already exists"));
        }
        
        if (await _userRepository.GetByUsernameAsync(username) is not null)
        {
            return Result.Failure(new Error("400", "Username already exists"));
        }

        var securedPassword = _passwordManager.Secure(password);
        
        var user = new Domain.Entity.User(userId, username,email, securedPassword, DateTime.Now.ToUniversalTime());
        await _userRepository.AddAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}