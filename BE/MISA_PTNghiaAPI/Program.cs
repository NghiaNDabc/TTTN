using Misa.Core.Entities;
using Misa.Core.Interfaces;
using Misa.Core.Services;
using MISA.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//tiêm sự phụ thuộc
builder.Services.AddScoped<IEmployeeRepo, EmployeeRepository>();
builder.Services.AddScoped<IBaseService<Employee>, EmployeeServices>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
