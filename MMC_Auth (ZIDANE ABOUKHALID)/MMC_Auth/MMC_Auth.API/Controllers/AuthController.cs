using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MMC_Auth.Application.Roles.Command;
using MMC_Auth.Application.Users.Command;
using MMC_Auth.Application.Users.Queries;
using MMC_Auth.Domain.Entitys;
using MMC_Auth.Domain.InterfacesServices;
using System.Security.Claims;

namespace Auth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IMediator mediator;

	public AuthController(IAuthServices authServices, IMediator mediator)
	{
		this.mediator = mediator;
	}
	[HttpPost("Register")]

	public async Task<IActionResult> Register([FromBody] CreateUser Model, CancellationToken cancellationToken)
	{
		try
		{
			var res = await mediator.Send(Model, cancellationToken);
			if (!res.IsAuthenticated)
				return BadRequest(res.Message);

			var codeAndidUser = await mediator.Send(new VerificationEmail(res.Email), cancellationToken);
			var callback_Url = Request.Scheme + "://" + Request.Host + Url.Action("ConfirmEmail", "Auth", new { id_user = codeAndidUser.user_id, code = codeAndidUser.code });
			var email_body = $"""
								<body style="font-family: Arial, sans-serif;">

				    <h2>Email Verification</h2>

				    <p>
				        Thank you for registering! To complete your registration, please click the following link:
				    </p>

				    <p>
				        <a href="{callback_Url}" style="display: inline-block; padding: 10px 20px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px;">
				            Verify Your Email
				        </a>
				    </p>

				    <p>
				        Thank you,
				        <br>
				        MMC
				    </p>

				</body>
				""";
			var sendemail = new SeendEmil(res.Email,
			email_body, "Verification Email"
				);
			var reqEmail = await mediator.Send(sendemail, cancellationToken);
			if (reqEmail)
				return Ok(res);
			return BadRequest("Error Send Email :( ");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}

	}

	[HttpPost("Login")]
	public async Task<IActionResult> Login([FromBody] loginUser Model, CancellationToken cancellationToken)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		try
		{
			var res = await mediator.Send(Model, cancellationToken);
			if (!res.IsAuthenticated)
				return BadRequest(res.Message);

			return Ok(res);
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPost("AddRolesToUser"), Authorize(Roles = "Admin")]
	public async Task<IActionResult> AddRoles([FromBody] AddRoleToUser addRoleToUser, CancellationToken cancellationToken)
	{
		if (!ModelState.IsValid)
			return BadRequest(ModelState);
		return Ok(await mediator.Send(addRoleToUser, cancellationToken));
	}


	[HttpPost("RegisterByGoogle")]
	public async Task<IActionResult> RegisterByGoogle([FromBody]CreateUserByGoogle createUserByGoogle, CancellationToken cancellationToken)
	{
		//var user = this.User;
		//string name = user.FindFirst(ClaimTypes.Name)?.Value;
		//string emailAddress = user.FindFirst(ClaimTypes.Email)?.Value;
		//var createUserByGoogle = new CreateUserByGoogle(name, $"{name.Replace(" ","_")}", emailAddress);
		return Ok(await mediator.Send(createUserByGoogle, cancellationToken));
	}

	[HttpPost("LoginWithGoogle")]
	public async Task<IActionResult> LoginWithGoogle([FromBody]loginUserWithGoogle loginUserWithGoogle, CancellationToken cancellationToken)
	{
		//var user = this.User;	
		//string emailAddress = user.FindFirst(ClaimTypes.Email)?.Value;
		//string LoginProvider = user.Identity.AuthenticationType;
		//var loginUserWithGoogle = new loginUserWithGoogle(emailAddress, LoginProvider);
		return Ok(await mediator.Send(loginUserWithGoogle, cancellationToken));

	}

	[HttpGet]
	public async Task<IActionResult> ConfirmEmail(string id_user, string code)
	{
		var ConfermEmail = await mediator.Send(new ValidationEmail(id_user, code));
		if (ConfermEmail)
			return Ok("user Id :=> " + id_user + "Is Confermed :)");
		else return BadRequest("This email is not Confermed");
	}

	[HttpGet("getEmailById/{ID}")]
	[Authorize]
	public async Task<IActionResult> getEmailById([FromRoute]string ID)
	{
		var email = await mediator.Send(new GetEmailById(ID.Trim()));
		return Ok(email);
	}

	[HttpGet("GetDataUserById/{ID}")]
	[Authorize]
	public async Task<IActionResult> GetDataUserById([FromRoute] string ID)
	{
		var data = await mediator.Send(new GetDataUserById(ID));
		return Ok(data);
	}
}
