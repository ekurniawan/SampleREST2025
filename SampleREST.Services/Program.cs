using Microsoft.EntityFrameworkCore;
using SampleREST.Services.DAL;
using SampleREST.Services.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection"));
});


//DI
builder.Services.AddScoped<ICategory, CategoryEF>();
builder.Services.AddScoped<IEmployee, EmployeeDapper>();
builder.Services.AddScoped<ICourse, CourseDapper>();

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

/*app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello ASP Core !");
});*/

app.Run();
