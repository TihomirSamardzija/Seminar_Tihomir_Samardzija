using Seminar_Tihomir_Samardzija.Models.Dto;
using Seminar_Tihomir_Samardzija.Models;
using Seminar_Tihomir_Samardzija.Data;
using Seminar_Tihomir_Samardzija.Models.Dbo;
using Seminar_Tihomir_Samardzija.Services.Implementation;
using Seminar_Tihomir_Samardzija.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => //options.SignIn.RequireConfirmedAccount = true)

{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Jti;

})

    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(CorsPolicy.AllowAll, builder => builder.WithOrigins("http://localhost:7289")
//        .AllowAnyHeader()
//        .AllowAnyMethod()
//        .AllowCredentials()
//        .SetIsOriginAllowed((host) => true));
//});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton<IIdentityService, IdentityService>();
//builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.Configure<AppConfig>(builder.Configuration);
builder.Services.AddSingleton<IIdentityService, IdentityService>();
builder.Services.AddScoped<IUserSevice, UserSevice>();
builder.Services.AddScoped<ISharedService, SharedService>();
builder.Services.AddScoped<IValidationService, ValidationService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
//builder.Services.AddSingleton<Microsoft.Extensions.Hosting.IHostedService, QueueProcessor>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();



//string tokenIssuerAndAudience = builder.Configuration["AppUrl"];
//string tokenKey = builder.Configuration["Identity:Key"];
//builder.Services.AddAuthentication().AddJwtBearer(options =>
//{

//    options.RequireHttpsMetadata = false;
//    options.SaveToken = true;
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidIssuer = tokenIssuerAndAudience,
//        ValidAudience = tokenIssuerAndAudience,
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey))
//    };
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Services.GetService<IIdentityService>();

app.Run();
