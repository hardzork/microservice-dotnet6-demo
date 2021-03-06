using microservicedotnet6.Data;
using microservicedotnet6.Models;
using microservicedotnet6.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseSwagger(swagger => swagger.SerializeAsV2 = true);

app.MapGet("/employees", ([FromServices] IEmployeeRepository db) =>
{
    return db.GetEmployees();
});

app.MapGet("/employee/{id}", ([FromServices] IEmployeeRepository db, string id) =>
{
    return db.GetEmployeeById(id);
});

app.MapPost("/employee", ([FromServices] IEmployeeRepository db, Employee employee) =>
{
    return db.AddEmployee(employee);
});

app.MapPut("/employee", ([FromServices] IEmployeeRepository db, Employee employee) =>
{
    return db.PutEmployee(employee);
});


app.Run();
