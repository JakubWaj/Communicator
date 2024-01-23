using Application.DTO;
using Domain.Entity;
using Domain.Exceptions;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.Message;
using Domain.ValueObjects.User;
using FluentAssertions;

namespace Api.Test.Unit.Entites;

public class MessageTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_Content_ShouldFail(string? content)
    {
     //ARRANGE
     Action action = () => { new Content(content); };
     //ACT
     
     //ASSERT
     action.Should().Throw<InvalidMessageContentException>();
    }
    
    [Fact]
    public void ConvertMessage_UserDto_ShouldSuccess()
    {
        //Assert
        var message = new Message()
        {
            Id = new MessageId(Guid.NewGuid()),
            Content = new Content("test"),
            UserId = new UserId(Guid.NewGuid()),
            GroupId = new GroupId(Guid.NewGuid()),
            CreatedAt = DateTime.Now
        };
        //Act       
        var messageDto = message.AsDto();
        //Assert
        messageDto.Should().NotBeNull();
        messageDto.Content.Should().Be(message.Content);
        messageDto.UserId.Should().Be(message.UserId);
    }
    
}