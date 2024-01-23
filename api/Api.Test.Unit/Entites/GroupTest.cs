using Application.DTO;
using Domain.Entity;
using Domain.Exceptions;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.Message;
using Domain.ValueObjects.User;
using FluentAssertions;

namespace Api.Test.Unit.Entites;

public class GroupTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("         ")]
    public void Create_Name_ShouldFail(string name)
    {
        //ARRANGE
        //ACT
        Action act = () => { new Name(name);};
        //ASSERT
        act.Should().Throw<InvalidGroupNameException>();
    }

    [Fact]
    public void ConvertGroup_GroupDto_ShouldSuccess()
    {
        var user = new User(new UserId(Guid.NewGuid()),new Username("test"),new Email("test@gmail.com"),new Password("testowy"),DateTime.Now);
        var group = new Groups(new GroupId(Guid.NewGuid()),new Name("test"),DateTime.Now);
        var message = new Message()
        {
            Id = new MessageId(Guid.NewGuid()),
            Content = new Content("testowanie"),
            UserId = user.Id,
            User = user,
            GroupId = group.Id,
            CreatedAt = DateTime.Now
        };
        group.Messages.Add(message);
        //Act
        var groupDto = group.AsDto();
        //Assert
        groupDto.Should().NotBe(null);
        groupDto.Name.Should().Be(group.Name);
        groupDto.Messages.Should().NotBeEmpty();
        groupDto.Messages.Should().OnlyContain(x=>x.Content.Equals(message.AsDto().Content));
        
    }

    
}
