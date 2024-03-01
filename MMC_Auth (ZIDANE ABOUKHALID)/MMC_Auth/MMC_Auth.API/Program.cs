using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MMC_Auth.Infrastructure;
using MMC_Auth.Application;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using MMC_Auth.Domain.Entitys;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//services Infra 

builder.Services.AddServicesInfrastructure(builder.Configuration);

//services Application 
builder.Services.AddServicesApplication();


builder.Services.Configure<IdentityOptions>(Options =>
{
	Options.User.AllowedUserNameCharacters = string.Empty;
}
);
// Add services to the container.
builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.SaveToken = true;
	options.RequireHttpsMetadata = false;
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidAudience = builder.Configuration["JWT:Audience"],
		ValidIssuer = builder.Configuration["JWT:Issuer"],
		ClockSkew = TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:key"]))
	};
});

builder.Services.AddAuthorization();

//builder.Services.AddAuthentication(options =>
//{
//	options.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
//	options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
//})
//	.AddGoogle(googleOption => {
//		googleOption.ClientId = builder.Configuration["AuthGoogle:client_id"];
//		googleOption.ClientSecret = builder.Configuration["AuthGoogle:client_secret"];
//	});
builder.Services.AddCors(options =>
{
	options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
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
app.UseCors("Open");

app.MapControllers();

app.Run();
