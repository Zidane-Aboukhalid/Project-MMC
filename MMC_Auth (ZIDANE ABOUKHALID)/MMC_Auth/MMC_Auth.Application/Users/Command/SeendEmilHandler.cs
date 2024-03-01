using MailKit.Net.Smtp;
using MediatR;
using Microsoft.Extensions.Options;
using MimeKit;
using MMC_Auth.Domain.Helpers;
using MMC_Auth.Domain.InterfacesServices;


namespace MMC_Auth.Application.Users.Command
{
	public class SeendEmilHandler : IRequestHandler<SeendEmil, bool>
	{
		private readonly IAuthServices authServices;
		private readonly SMTPSettings SMTPSettings;

		public SeendEmilHandler(IAuthServices authServices,IOptions<SMTPSettings> options )
        {
			this.authServices = authServices;
			this.SMTPSettings = options.Value;
		}
        public async Task<bool> Handle(SeendEmil seendEmil, CancellationToken cancellationToken)
		{
			try
			{
			var email = new MimeMessage();
			email.Sender=new MailboxAddress("MMC_Verification",SMTPSettings.Email );
			email.From.Add(new MailboxAddress("MMC Verification", SMTPSettings.Email));
			email.To.Add(MailboxAddress.Parse(seendEmil.Email ));
			email.Subject = seendEmil.subject;
			var builder = new BodyBuilder();
			builder.HtmlBody = seendEmil.body;
			email.Body=builder.ToMessageBody();
			using var smtp = new SmtpClient();
			smtp.Connect(SMTPSettings.Host,SMTPSettings.Port,MailKit.Security.SecureSocketOptions.StartTls);
			smtp.Authenticate(SMTPSettings.Email,SMTPSettings.Password);
			var res= await smtp.SendAsync(email);
			smtp.Disconnect(true);
			return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}

//StartTls SslOnConnect

//RestClient restClient = new RestClient("https://api.mailgun.net/v3");
//var request = new RestRequest("", Method.Post);
//restClient.Authenticator = new HttpBasicAuthenticator("api", "2cb211ede81d58cf227913d1ef52628a-063062da-5a99abf8");
//request.AddParameter("domain", "postmaster@sandboxe4ddced5c5d04b0c93c1f69ed62e845d.mailgun.org", ParameterType.UrlSegment);
//request.Resource = "{domain}/messages";
//request.AddParameter("from", "Aboukhalid zizo Mailgun Sandbox < postmaster@sandboxe4ddced5c5d04b0c93c1f69ed62e845d.mailgun.org>");
//request.AddParameter("to", "Aboukhalid zizo <zidancastro12345@gmail.com>");
//request.AddParameter("to", seendEmil.Email);
//request.AddParameter("subject", "Email Verification");
//request.AddParameter("text", seendEmil.body);
//request.Method = Method.Post;
//var Response = restClient.Execute(request);

//return Response.IsSuccessful;
