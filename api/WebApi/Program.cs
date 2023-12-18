using Application;
using Application.Commands.User.SignUpUser;
using Domain.Repository;
using Domain.ValueObjects.Group;
using Infrastructure;
using Infrastructure.DAL;
using Infrastructure.DAL.Repositories;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();
app.MapPost("/SignUp2", async (SignUpCommand command, IMediator mediator) =>
    {
        command = command with {UserId = Guid.NewGuid()};
        var result = await mediator.Send(command);
        return result;
    })
    .WithName("SignUp")
    .WithOpenApi();

app.MapGet("testowankoDD", async (IGroupRepository groupRepository) =>
{
    var group = await groupRepository.GetByIdAsync(new GroupId(Guid.Parse("bc60ea65-2866-4c50-a41d-43effad0426d")));
    return group;
});
app.Run();
