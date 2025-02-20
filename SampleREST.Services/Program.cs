using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SampleREST.Services.DAL;
using SampleREST.Services.Helpers;
using SampleREST.Services.ModelEF;
using SampleREST.Services.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF
/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection"));
});*/

builder.Services.AddDbContext<RapidDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RapidDbConnection"));
});


//DI
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<ICustomer, CustomerServices>();
//builder.Services.AddScoped<ICategory, CategoryEF>();
builder.Services.AddScoped<IEmployee, EmployeeDapper>();
//builder.Services.AddScoped<ICourse, CourseDapper>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Configure Azure AD authentication  
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
 .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

//jwt token
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

/*app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello ASP Core !");
});*/

app.Run();
