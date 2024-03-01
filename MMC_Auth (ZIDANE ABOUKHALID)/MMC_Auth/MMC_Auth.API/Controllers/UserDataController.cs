using MediatR;
using Microsoft.AspNetCore.Mvc;
using MMC_Auth.Application.Users.Command;
using MMC_Auth.Application.Users.Queries;
using System.Threading;

namespace MMC_Auth.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(Roles ="Admin")]
	public class UserDataController : ControllerBase
	{
		private readonly IMediator mediator;

		public UserDataController(IMediator mediator)
        {
			this.mediator = mediator;
		}

		[HttpGet("GetCountUser")]
		public async Task<IActionResult> GetCountUser(CancellationToken cancellationToken)
		{
			return Ok( await mediator.Send(new GetCountUsers(), cancellationToken));
		}

		[HttpPost("VerificationValidationEmail")]
		public async Task<IActionResult> CheckVerificationEmail([FromBody]CheckVerificationEmail checkVerificationEmail, CancellationToken cancellationToken) {
			return Ok(await mediator.Send(checkVerificationEmail, cancellationToken));
		}

		[HttpPost("VerificationSender")]
		public async Task<IActionResult> VerificationSender([FromBody] string Email,CancellationToken cancellationToken)
		{
			try
			{

				var codeAndidUser = await mediator.Send(new VerificationEmail(Email), cancellationToken);
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
				var sendemail = new SeendEmil(Email,
				email_body, "Verification Email"
					);
				var reqEmail = await mediator.Send(sendemail, cancellationToken);
				if (reqEmail)
					return Ok("Succes Send Email");
				return BadRequest("Error Send Email :( ");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpGet("getUserDataByEmail/{email}")]
		public async Task<IActionResult> getUserDataByEmail([FromRoute]string email,CancellationToken cancellationToken)
		{
			return Ok(await mediator.Send(new GetDataUserByEmail(email),cancellationToken));
		}



	}
}
