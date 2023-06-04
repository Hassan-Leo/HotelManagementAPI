using HotelManagementAPI.Models;
using HotelManagementAPI.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HotelBookingManagementContext>(options =>
{
	options.UseSqlServer(connectionString, opt => opt.EnableRetryOnFailure());
});
builder.Services.AddControllers();
builder.Services.AddIdentity<User, IdentityRole>(x => 
{
	x.Lockout.AllowedForNewUsers = false;
}).AddEntityFrameworkStores<HotelBookingManagementContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();


builder.Services.AddCors(options =>
{
	options.AddPolicy("EnableCORS", builder =>
	{
		builder.AllowAnyOrigin()
		.AllowAnyHeader()
		.AllowAnyMethod();
	});
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
	x.SwaggerDoc("v2", new OpenApiInfo { Title = "Hotel Management APIs", Version = "v2" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(x =>
	{
		x.SwaggerEndpoint("/swagger/v2/swagger.json", "Hotel Management APIs V2");
	});
}

app.UseHttpsRedirection();
app.UseCors("EnableCORS");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
