using Application.Abstraction;
using Domain.Entity;
using Domain.Repository;
using Domain.Shared;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.User;

namespace Application.Commands.Group.AddUserToGroup;

public class AddUserToGroupCommandHandler : ICommandHandler<AddUserToGroupCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddUserToGroupCommandHandler(IUserRepository userRepository, IGroupRepository groupRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(AddUserToGroupCommand request, CancellationToken cancellationToken)
    {
        UserId userId = request.UserId;
        GroupId groupId = request.GroupId;
        var user = await _userRepository.GetByIdAsync(userId);
        var group =await  _groupRepository.GetByIdAsync(groupId);
        if (user is null || group is null)
        {
            return Result.Failure(new Error("400", "Invalid credentials"));
        }

        if (group.Users.Any(x => x.UserId == userId))
        {
            return Result.Failure(new Error("400", "User already in group"));
        }
        
        var groupUser = new GroupUser()
        {
            GroupId = groupId,
            UserId = userId
        };
        group.Users.Add(groupUser);
        await _groupRepository.AddUserToGroupAsync(groupUser);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}