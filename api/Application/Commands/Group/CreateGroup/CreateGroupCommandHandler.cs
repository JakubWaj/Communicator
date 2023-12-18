using Application.Abstraction;
using Domain.Entity;
using Domain.Repository;
using Domain.Shared;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.User;

namespace Application.Commands.Group.CreateGroup;

public class CreateGroupCommandHandler : ICommandHandler<CreateGroupCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGroupRepository _groupRepository;
    private readonly IUserRepository _userRepository;

    public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IGroupRepository groupRepository, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _groupRepository = groupRepository;
        _userRepository = userRepository;
    }
    
    public async Task<Result> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        UserId userId = new UserId(request.UserId);
        UserId otherUserId = new UserId(request.OtherUserId);
        Name name = new Name(request.Name);
        var user = await _userRepository.GetByIdAsync(userId);
        var otherUser = await _userRepository.GetByIdAsync(otherUserId);
        if (user is null || otherUser is null)
        {
            return Result.Failure(new Error("400", "Invalid credentials"));
        }
        var group = new Groups(Guid.NewGuid(), name, DateTime.Now.ToUniversalTime());
        var groupuser = new GroupUser()
        {
            GroupId = group.Id,
            UserId = userId
        };
        var otherGroupUser = new GroupUser()
        {
            GroupId = group.Id,
            UserId = otherUserId
        };
        group.Users.Add(otherGroupUser);
        group.Users.Add(groupuser);
        await _groupRepository.AddAsync(group);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}