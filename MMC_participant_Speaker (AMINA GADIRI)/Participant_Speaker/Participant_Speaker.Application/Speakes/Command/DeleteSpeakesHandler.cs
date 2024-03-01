using MediatR;
using Microsoft.AspNetCore.Hosting;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Command
{
	public class DeleteSpeakesHandler : IRequestHandler<DeleteSpeakes,int>
	{
		private readonly ISpeakerRepository speakerRepository;
		private readonly IWebHostEnvironment webHostEnvironment;

		public DeleteSpeakesHandler(ISpeakerRepository speakerRepository ,IWebHostEnvironment webHostEnvironment)
        {
			this.speakerRepository = speakerRepository;
			this.webHostEnvironment = webHostEnvironment;
		}

		public async Task<int> Handle(DeleteSpeakes request, CancellationToken cancellationToken)
		{
			var speaker = await speakerRepository.GetSpeakerByIdAsync(request.Id);
			var ImagName = $"Img_spk_{speaker.SpeakerID}";
			var ImagExten = Path.GetExtension(speaker.UrlImag);
			var urlOldImg = Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot/Img_Speakers/", $"{ImagName}{ImagExten}");
			// Supprimer l'ancien fichier image s'il existeSS
			if (System.IO.File.Exists(urlOldImg))
			{
				System.IO.File.Delete(urlOldImg);
			}

			return await speakerRepository.DeleteSpeakerAsync(request.Id);
		}
	}
}
