
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using MMC_Auth.Domain.InterfacesServices;
using MMC_Auth.Domain.Entitys;
using MMC_Auth.Infrastructure.Helpers;
using MMC_Auth.Domain.models;

namespace Infra.Services;

public class AuthServices : IAuthServices
{
	private readonly UserManager<User> userManager;
	private readonly RoleManager<IdentityRole> roleManager;
	private readonly JWT Jwt;
	public AuthServices(UserManager<User> userManager
		, IOptions<JWT> _Jwt ,
		RoleManager<IdentityRole> roleManager)
    {
		this.userManager = userManager;
		this.Jwt = _Jwt.Value;
		this.roleManager = roleManager;
	}


	public async Task<AuthModel> RegisterAsync(ResgisterModel resgisterModel)
	{
		if (await userManager.FindByEmailAsync(resgisterModel.Email) is not null)
			return new AuthModel { Message = "Email is already registered ! " };

		else if(await userManager.FindByNameAsync(resgisterModel.Username) is not null)
			return new AuthModel { Message = "Username is already registered ! " };
		var user = new User
		{
			UserName= resgisterModel.Username,
			Email= resgisterModel.Email,
			FullName= resgisterModel.fullName,
			EmailConfirmed=false
		};
		var resulte = await userManager.CreateAsync(user,resgisterModel.Password);

		if (!resulte.Succeeded)
		{
			var Error = string.Empty;
			var c = 0;
			foreach (var error in resulte.Errors)
			{
				c++;
				Error += $"error {c}: {error.Description} ; \n";
			}
			return new AuthModel { Message = Error };
		}
		await userManager.AddToRoleAsync(user, "User");
		var jwtSecurityToken = await GenerateToken(user);


		var authMoel= new AuthModel
		{
			Message="Verification you Email",
			Email=user.Email,
			ExpiresOn = DateTime.UtcNow,
			IsAuthenticated=true,
			Roles=new List<string> {"User"},
			Token= jwtSecurityToken,
			UserName=user.UserName,
			Id=user.Id
		};
		return authMoel; 
	}

	public async Task<AuthModel> LoginAsync(LoginModel Model)
	{
		var AuthModel = new AuthModel();
		var user = await userManager.FindByEmailAsync(Model.Email);
		if(user is null ||! await userManager.CheckPasswordAsync(user, Model.Password))
		{
			AuthModel.Message = "Email or Password is incorrect !";
			return AuthModel;
		}


		var jwtSecurttyToken = await GenerateToken(user);
		AuthModel.IsAuthenticated = true;
		AuthModel.Token= jwtSecurttyToken;
		AuthModel.Email= Model.Email;
		AuthModel.UserName = user.UserName;
		AuthModel.ExpiresOn = DateTime.UtcNow; 
		AuthModel.Id = user.Id;


		var roles = await userManager.GetRolesAsync(user);
		AuthModel.Roles = roles.ToList();

		return AuthModel;
	}

	public async Task<string> AddRolesToUser(RolesToUserModel rolesToUserModel)
	{
		var user = await userManager.FindByIdAsync(rolesToUserModel.Id);
		if (user is null || !await roleManager.RoleExistsAsync(rolesToUserModel.Role))
			return "Invalid user ID or Role";
		if (await userManager.IsInRoleAsync(user, rolesToUserModel.Role))
			return "User already assigned to this Role";

		var resulte = await userManager.AddToRoleAsync(user, rolesToUserModel.Role);
		
			return resulte.Succeeded ?  "Add Roles Secceces" : "Soneththg wert wrong";
	}
	//create Token JWT To Login and Sign up
	private async Task<string> GenerateToken(User user)
	{
		var UserClaims = await userManager.GetClaimsAsync(user);
		var roles = await userManager.GetRolesAsync(user);
		var roleClaims = new List<Claim>();
		foreach (var role in roles)
			roleClaims.Add(new Claim("roles", role));
		var Claims = new[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			new Claim(JwtRegisteredClaimNames.Email, user.Email),
			new Claim("uid", user.Id)
		}
		.Union(UserClaims)
		.Union(roleClaims);

		var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.key));
		var TokenExpiryTimeInDay = Convert.ToInt64(Jwt.DurationInDay);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Issuer = Jwt.Issuer,
			Audience = Jwt.Audience,
			Expires = DateTime.UtcNow.AddDays(TokenExpiryTimeInDay),
			SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
			Subject = new ClaimsIdentity(Claims)
		};

		var tokenHandler = new JwtSecurityTokenHandler();
		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}

	public async Task<AuthModel> RegisterGoogleAsync(ResgisterGoogleModel resgisterGoogleModel)
	{
		if (await userManager.FindByEmailAsync(resgisterGoogleModel.Email) is not null)
			return new AuthModel { Message = "Email is already registered ! " };

		//else if (await userManager.FindByNameAsync(resgisterGoogleModel.Username) is null)
		//	return new AuthModel { Message = "Username is already registered ! " };
		Random rnd = new Random();
		var user = new User
		{
			EmailConfirmed = true,
			Email = resgisterGoogleModel.Email,
			FullName = resgisterGoogleModel.fullName,
			UserName =$"{resgisterGoogleModel.Username.ToUpper()}{rnd.Next(1,1000)}"
		};
		var resulte = await userManager.CreateAsync(user);

		if (!resulte.Succeeded)
		{
			var Error = string.Empty;
			var c = 0;
			foreach (var error in resulte.Errors)
			{
				c++;
				Error += $"error {c}: {error.Description} ; \n";

			}
			return new AuthModel { Message = Error };
		}
		await userManager.AddToRoleAsync(user, "User");
		var jwtSecurityToken = await GenerateToken(user);

		return new AuthModel
		{
			Email = user.Email,
			ExpiresOn = DateTime.UtcNow,
			IsAuthenticated = true,
			Roles = new List<string> { "User" },
			Token = jwtSecurityToken,
			UserName = user.UserName,
			Id = user.Id
		};
	}

	public async Task<AuthModel> LoginGoogleAsync(LoginGoogleModel Model)
	{
		var AuthModel = new AuthModel();
		var user = await userManager.FindByEmailAsync(Model.Email);
		if(user == null)
		{
			AuthModel.Message = "User is null !";
			return AuthModel;
		}
		if (Model.provaiderName.ToUpper()!="Google".ToUpper())
		{
			AuthModel.Message = "LoginProvider is incorrect !";
			return AuthModel;
		}
		var userInfo = new UserLoginInfo(Model.provaiderName, user.UserName, Model.provaiderName.ToUpper());

		var jwtSecurttyToken = await GenerateToken(user);
		AuthModel.IsAuthenticated = true;
		AuthModel.Token = jwtSecurttyToken;
		AuthModel.Email = Model.Email;
		AuthModel.UserName = user.UserName;
		AuthModel.Id = user.Id;
		AuthModel.ExpiresOn = DateTime.UtcNow;

		var roles = await userManager.GetRolesAsync(user);
		AuthModel.Roles = roles.ToList();

		var ResAddLogin = await userManager.AddLoginAsync(user, userInfo);

		return AuthModel;
	}


	public async Task<VerificationEmailModel> GenerateEmailConfirmationTokenAsync(string email)
	{
		var user = await userManager.FindByEmailAsync(email);
		if (user != null)
		{
			return new VerificationEmailModel
			{
				user_id = user.Id,
				code = await userManager.GenerateEmailConfirmationTokenAsync(user)
			};
		}
		return null;
	}

	public async Task<bool> ValidationEmail(ValidationEmailModel validationEmailModel)
	{
		var user = await userManager.FindByIdAsync(validationEmailModel.id);
		if (user != null && validationEmailModel.code.Trim()!=string.Empty )
		{
			//var Code = Encoding.UTF8.GetString(Convert.FromBase64String(validationEmailModel.code));
			var res = await userManager.ConfirmEmailAsync(user, validationEmailModel.code);
			return res.Succeeded;
		}
		else
		{
			return false;
		}
	}


	public async Task<string> GetEmailById(string id)
	{
		var user = await userManager.FindByIdAsync(id);
		if (user != null)
			return user.Email;
		return null;
	}

	public async Task<userData> GetDataUserByEmailAsync(string Email)
	{
		var user = await userManager.FindByEmailAsync(Email);
		if (user != null)
			return new userData
			{
				id = user.Id,
				email = user.Email,
				fullname=user.FullName
			};
		return null;
	}

	public async Task<userData> GetDataUserByIdAsync(string id)
	{
		var user = await userManager.FindByIdAsync(id);
		if (user != null)
			return new userData
			{
				id = user.Id,
				email = user.Email,
				fullname = user.FullName
			};
		return null;
	}


	public async Task<int> GetCountUsersAsync()
	{
		return userManager.Users.Count();
	}

	public async Task<bool> CheckVerificationEmailDone(string email)
	{
		var user = await userManager.FindByEmailAsync(email);
		if(user != null)
			return user.EmailConfirmed;
		return false;
	
	}
}

