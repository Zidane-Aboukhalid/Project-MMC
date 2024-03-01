using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Command
{
	public class UpdateSpeakesHandler:IRequestHandler<UpdateSpeakes,int>
	{
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly ISpeakerRepository speakerRepository;
		private readonly IWebHostEnvironment webHostEnvironment;

		public UpdateSpeakesHandler(
			IHttpContextAccessor httpContextAccessor,
			ISpeakerRepository speakerRepository,
			IWebHostEnvironment webHostEnvironment)
        {
			this.httpContextAccessor = httpContextAccessor;
			this.speakerRepository = speakerRepository;
			this.webHostEnvironment = webHostEnvironment;
		}

		public async Task<int> Handle(UpdateSpeakes request, CancellationToken cancellationToken)
		{
			var speaker = await speakerRepository.GetSpeakerByIdAsync(request.SpeakerID);
			
			if(speaker!=null)
			{
				var ImagName = $"Img_spk_{speaker.SpeakerID}";
				var ImagExten = Path.GetExtension(speaker.UrlImag);
				var urlOldImg = Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot/Img_Speakers/", $"{ImagName}{ImagExten}");
				if(System.IO.File.Exists(urlOldImg))
				{
					System.IO.File.Delete(urlOldImg);
				}


				var spk = new Speaker
				{
					SpeakerID = request.SpeakerID,
					IdUser = request.IdUser,
					IsMCT = request.IsMCT,
					IsMVP = request.IsMVP,
					UpdateAt = DateTime.Now,
					Biographi = request.Biographi,
				};
				string hosturl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
				var ExtenImag = Path.GetExtension(request.File.FileName);
				var localeFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "wwwroot/Img_Speakers/", $"{ImagName}{ExtenImag}");

				using (var fileStream = new FileStream(localeFilePath, FileMode.Create))
				{
					await request.File.CopyToAsync(fileStream);
				}
				spk.UrlImag = $"{hosturl}/uploadsGallery/{ImagName}{ImagExten}";

				return await speakerRepository.UpdateSpeakerAsync(spk);
			}
			return 0;

			
		}
	}
}
