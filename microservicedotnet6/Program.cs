using microservicedotnet6.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();



app.MapGet("/", () => "Hello World!");

app.MapGet("/employee", (Func<Employee>)(() =>
{
    return new Employee()
    {
        EmployeeId = new Guid().ToString(),
        Name = "Robinson",
        Citizenship = "Brazilian"
    };
}));

app.MapGet("/employees", (Func<List<Employee>>)(() =>
{
    return new EmployeeCollection().GetEmployees();
}));

app.MapGet("/employee/{id}", async (http) =>
{
    if (!http.Request.RouteValues.TryGetValue("id", out var id))
    {
        http.Response.StatusCode = 400;
        return;
    }
    await http.Response.WriteAsJsonAsync(new EmployeeCollection().GetEmployees().FirstOrDefault(e => e.EmployeeId == (string)id));
});

app.Run();
