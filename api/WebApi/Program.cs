using Application;
using Application.Commands.User.SignUpUser;
using Infrastructure;
using Infrastructure.DAL;
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

app.Run();
