using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;
using Participant_Speaker.Domain.Modales;
using Polly;
using RestSharp;


namespace Participant_Speaker.Application.Participants.Command;

public class AddParticipantHandler : IRequestHandler<AddParticipant,int>
{
	private readonly IParticipantRepository participantRepository;
	private readonly IMediator mediator;
	private readonly IHttpContextAccessor httpContextAccessor;

	private SessionResponse sessionResponse { get; set; }
	private userData userData {  get; set; }

	public AddParticipantHandler(IParticipantRepository participantRepository , IMediator mediator, IHttpContextAccessor httpContextAccessor)
    {
		this.participantRepository = participantRepository;
		this.mediator = mediator;
		this.httpContextAccessor = httpContextAccessor;
	}

	public async Task<int> Handle(AddParticipant request, CancellationToken cancellationToken)
	{
		var GetAllParticipant = await participantRepository.GetAllParticipantsAsync();
		var countPar= GetAllParticipant.Count(x=> x.IdSession==request.IdSession);
		var Par = new Participant
		{
			ParticipantId = Guid.NewGuid(),
			DateJoin = DateTime.Now,
			IdUser = request.IdUser,
			IdSession = request.IdSession
		};
		var retryPolicy = Policy
			   .Handle<Exception>().
			   WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(15), (exception, retryCount) =>
			   {
				   Console.WriteLine("Error:" + exception.Message + ".. Retry Count : " + retryCount);
			   });
		var circuitBreakerPolicy = Policy
			.Handle<Exception>()
			.CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));
		var finalPolicy = retryPolicy.WrapAsync(circuitBreakerPolicy);

		await finalPolicy.ExecuteAsync(async () => {
			Console.WriteLine("Executing");
			await ConnectApiAsync(request);
		});


		if(sessionResponse != null && sessionResponse.NbrPlace> countPar)
		{

			// Subject
			var subject = $"{userData.fullname}, You've Successfully Joined the Session: {sessionResponse.Name}";

			// Body
			var body = $@"
<html>
<head>
    <style>
        body {{
            font-family: 'Arial', sans-serif;
            color: #333;
        }}
        .container {{
            max-width: 600px;
            margin: 0 auto;
        }}
        .header {{
            background-color: #007bff;
            color: #fff;
            padding: 20px;
            text-align: center;
        }}
        .content {{
            padding: 20px;
        }}
        .footer {{
            background-color: #f8f8f8;
            padding: 10px;
            text-align: center;
        }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>{subject}</h1>
        </div>
        <div class='content'>
            <p>Dear {userData.fullname},</p>
            <p>Congratulations! You have successfully joined the session. Here are the details:</p>
            <ul>
                <li><strong>Session ID:</strong> {request.IdSession}</li>
                <li><strong>Date Joined:</strong> {DateTime.Now.AddHours(1):yyyy-MM-dd HH:mm:ss}</li>
            </ul>
            <p>Thank you for participating!</p>
        </div>
        <div class='footer'>
            <p>This is a notification from the session system.</p>
        </div>
    </div>
</body>
</html>
";
			// fin body 

			var sender=	await mediator.Send(new SeendEmil(userData.email, body,subject));
			if (sender)
				return await participantRepository.AddParticipantAsync(Par);
			else
				return 3;
		}
		else
		{
			return 0;
		}
		

	}

	private async Task ConnectApiAsync(AddParticipant request)
	{

		var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
		var url = $"https://mmc-event-session.azurewebsites.net/api/v1/Session/GetById/{request.IdSession}";
		var client = new RestClient(url);
		var requestGet = new RestRequest(url, Method.Get);
		requestGet.AddHeader("Authorization", $"Bearer {token.Trim()}");
		requestGet.AddHeader("Accept", "application/json");


		try
		{
			var response = await client.ExecuteAsync(requestGet);

			if (response.IsSuccessful)
			{
				// Deserialize the response into SessionResponse
				sessionResponse = JsonConvert.DeserializeObject<SessionResponse>(response.Content);
				url = $"https://mmc-authentification.azurewebsites.net/api/Auth/GetDataUserById/{request.IdUser}"; 
				client = new RestClient(url);
				requestGet = new RestRequest(url, Method.Get);
				requestGet.AddHeader("Authorization", $"Bearer {token.Trim()}");
				requestGet.AddHeader("accept", "application/json");
				response = await client.ExecuteAsync(requestGet);

				if (response.IsSuccessful)
				{
					userData = JsonConvert.DeserializeObject<userData>(response.Content); ;
				}
			else
			{
				// Handle errors
				Console.WriteLine($"Error: {response.ErrorMessage}");
			}
		}
		}
		catch (HttpRequestException ex)
		{
			// Handle HTTP-related exceptions
			Console.WriteLine($"HTTP Exception: {ex.Message}");
		}
		catch (JsonException ex)
		{
			// Handle JSON deserialization issues
			Console.WriteLine($"JSON Exception: {ex.Message}");
		}
		catch (Exception ex)
		{
			// Handle other exceptions
			Console.WriteLine($"Exception: {ex.Message}");
		}
	}

	private void GeneretQRcode(string data)
	{
		
	}
}
