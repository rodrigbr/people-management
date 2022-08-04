using System.Data;
using FluentValidation.Results;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using People.Management.Application.CommandHandlers;
using People.Management.Application.Commands;
using People.Management.Application.Contracts;
using People.Management.Application.Implementations;
using People.Management.Domain.Contracts;
using People.Management.Infra.Context;
using People.Management.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MediatR
builder.Services.AddMediatR(typeof(WebApplication).Assembly);

//EF and Dapper connections respectively
builder.Services.AddDbContext<MicroServiceContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IDbConnection>((sp) => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

//Write Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISchoolingRepository, SchoolingRepository>();
builder.Services.AddScoped<ISchoolRecordRepository, SchoolRecordRepository>();

//Read Repositories
builder.Services.AddScoped<IUserDapperRepository, UserDapperRepository>();

//Services
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();

// Domain - Commands
builder.Services.AddScoped<IRequestHandler<CreateUserCommand, ValidationResult>, UserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateUserCommand, ValidationResult>, UserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteUserCommand, ValidationResult>, UserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateSchoolingCommand, ValidationResult>, UserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<UpdateSchoolRecordCommand, ValidationResult>, UserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteSchoolRecordCommand, ValidationResult>, UserCommandHandler>();
builder.Services.AddScoped<IRequestHandler<DeleteSchoolingCommand, ValidationResult>, UserCommandHandler>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "People.Management.WebApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
