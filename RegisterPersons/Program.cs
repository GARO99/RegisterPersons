using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RegisterPersons.Data;
using RegisterPersons.Rules.Contracts;
using RegisterPersons.Rules.Services;
using RegisterPersons.Util.Request;
using RegisterPersons.Util.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Database connection
builder.Services.AddDbContext<RegisterPersonsContext>(opt => opt.UseInMemoryDatabase(databaseName: builder.Configuration.GetConnectionString("DefaultConnection") ?? ""));
//Validators
builder.Services.AddScoped<IValidator<PersonRequest>, PersonValidator>();
//Dependency injection
builder.Services.AddScoped<IPersonService, PersonService>()
    .AddScoped(serviceProvider => new Lazy<IPersonService>(() => serviceProvider.GetRequiredService<IPersonService>()));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<RegisterPersonsContext>();
context.Database.EnsureCreated();

app.Run();
