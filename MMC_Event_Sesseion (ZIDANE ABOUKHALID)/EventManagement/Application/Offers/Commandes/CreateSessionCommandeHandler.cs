using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Polly;
using RestSharp;
using System;
using System.Security.Policy;

namespace Application.Offers.Commandes
{
    public class CreateSessionCommandeHandler : IRequestHandler<CreateSessionCommandeRequest, AddSessionDto>
    {
        private readonly ISessionRepository sessionRepository;
        private readonly IMapper mapper;
		private readonly IHttpContextAccessor httpContextAccessor;

		public CreateSessionCommandeHandler(ISessionRepository sessionRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.sessionRepository = sessionRepository;
            this.mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
		}

        public async Task<AddSessionDto> Handle(CreateSessionCommandeRequest request, CancellationToken cancellationToken)
        {
            var session = mapper.Map<Session>(request.SessionRequest);
            session.Id=Guid.NewGuid();

            var retryPolicy = Policy
                .Handle<Exception>().
                WaitAndRetryAsync(3, i => TimeSpan.FromSeconds(15), (exception, retryCount) =>
                {
                    Console.WriteLine("Error:" + exception.Message + ".. Retry Count : " + retryCount);
                });
            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(7, TimeSpan.FromSeconds(15));
			var finalPolicy = retryPolicy.WrapAsync(circuitBreakerPolicy);
			await finalPolicy.ExecuteAsync(async () =>
            {
                Console.WriteLine("Executing");
                await ConnectApiAsync(session.Id,request.SessionRequest.TargetAudienceId);
                await sessionRepository.CreateAsync(session);
			});

			return mapper.Map<AddSessionDto>(session);

		}
		private async Task ConnectApiAsync(Guid IdSession , Guid targetAudienceId)
        {
			var token = httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            
			var apiUrl = "https://mmc-parametrage-session.azurewebsites.net/api/SessionTargetAudience/CreateSessionTargetAudience"; // URL complète du service TargetAudienceController
			var objetAEnvoyer = new
            {
				sessionId = IdSession,
				targetAudienceId = targetAudienceId
			};
			var client = new RestClient(apiUrl);
			var request = new RestRequest(apiUrl,Method.Post);
			//var restRequest = new RestRequest("TargetAudience");
			request.AddHeader("Authorization", $"Bearer {token.Trim()}");
			request.AddHeader("Accept", "application/json"); 
			request.AddJsonBody(objetAEnvoyer);

			try
            {
                var response = await client.ExecuteAsync(request);

                if (response.IsSuccessful)
                {
                    // Gérer la réponse réussie
                    Console.WriteLine("L'élément a été envoyé avec succès.");
                }
                else
                {
                    // Gérer les erreurs
                    Console.WriteLine("Error ::" + response.StatusCode);
                    Console.WriteLine($"Erreur : {response.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                // Gérer les exceptions
                Console.WriteLine($"Exception : {ex.Message}");
            }
        }
    }
}
