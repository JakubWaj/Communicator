using Application.DTO;
using Domain.Entity;
using Domain.Exceptions;
using Domain.Repository;
using Domain.ValueObjects.Group;
using Domain.ValueObjects.User;
using FluentAssertions;

namespace Api.Test.Unit.Entites;

public class UserTest
{    
    [Theory]
    [InlineData("abc")]
    [InlineData("123")]
    [InlineData("abc34")]
    public void Create_Password_ShouldFail(string password)
    {
        //ARRANGE
        //ACT
        Action act = () => { new Password(password);};
        //ASSERT
        act.Should().Throw<InvalidPasswordException>();
    }
    
    [Theory]
    [InlineData("kowalski")]
    [InlineData("kowalski@")]
    [InlineData("@kowalski.com")]
    [InlineData("kowalski@wp")]
    [InlineData("")]
    [InlineData(null)]
    public void Create_Email_ShouldFail(string email)
    {
        //ARRANGE
        //ACT
        Action act = () => { new Email(email);};
        //ASSERT
        act.Should().Throw<InvalidEmailException>();
    }
    
    [Theory]
    [InlineData("kowalskikowalskikowalskikowalskikowalskikowalskikowalskikowalskikowalskikowalskikowalski")]
    [InlineData("ds")]
    public void Create_Username_ShouldFail(string username)
    {
        //ARRANGE
        //ACT
        Action act = () => { new Username(username); };
        //ASSERT
        act.Should().Throw<InvalidUsernameException>();
    }
    [Theory]
    [InlineData("kowalski","string@gmail.com","string")]
    public void ConvertUser_UserDto_ShouldSuccess(string username,string email,string password)
    {
        //Assert
        var user = new User(new UserId(Guid.NewGuid()),new Username(username),new Email(email),new Password(password),DateTime.Now);
        //Act       
        var userDto = user.AsDto();
        //Assert
        userDto.Should().NotBeNull();
        userDto.Username.Should().Be(user.Username);
        userDto.Email.Should().Be(user.Email);
        userDto.Id.Should().Be(user.Id);
    }
}