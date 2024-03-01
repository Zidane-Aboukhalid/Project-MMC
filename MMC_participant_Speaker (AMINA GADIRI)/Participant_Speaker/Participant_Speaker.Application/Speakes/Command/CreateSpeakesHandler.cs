using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using Participant_Speaker.Domain.Identity;
using Participant_Speaker.Domain.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participant_Speaker.Application.Speakes.Command;

public class CreateSpeakesHandler : IRequestHandler<CreateSpeakes, int>
{
	private readonly ISpeakerRepository speakerRepository;
	private readonly IWebHostEnvironment webHostEnvironment;
	private readonly IHttpContextAccessor httpContextAccessor;

	public CreateSpeakesHandler(ISpeakerRepository speakerRepository, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
    {
		this.speakerRepository = speakerRepository;
		this.webHostEnvironment = webHostEnvironment;
		this.httpContextAccessor = httpContextAccessor;
	}
    public async Task<int> Handle(CreateSpeakes request, CancellationToken cancellationToken)
	{
		if (ValidateFileUpload(request.FormFile))
		{
			var speaker = new Speaker
			{
				SpeakerID = Guid.NewGuid(),
				IdUser = request.IdUser,
				CreateAt = DateTime.Now,
				IsMCT = request.IsMCT,
				IsMVP = request.IsMVP,
				Biographi = request.Biographi,
			};
			var ImagName = $"Img_spk_{speaker.SpeakerID}";
			var ImagExten = Path.GetExtension(request.FormFile.FileName);
			string hosturl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{httpContextAccessor.HttpContext.Request.PathBase}";
			var localeFilePath = Path.Combine(
				webHostEnvironment.ContentRootPath,
				"wwwroot/Img_Speakers/", $"{ImagName}{ImagExten}"
			);

			using (var stream = new FileStream(localeFilePath, FileMode.Create))
			{
				await request.FormFile.CopyToAsync(stream);
			}
			speaker.UrlImag = $"{hosturl}/Img_Speakers/{ImagName}{ImagExten}";
			return await speakerRepository.CreateSpeakerAsync(speaker);
		}
		return 0;
		
	}

	private bool ValidateFileUpload(IFormFile formFile)
	{
		var allowExtensions = new string[] { ".png", ".jpeg", ".jpg" };

		if (!allowExtensions.Contains(Path.GetExtension(formFile.FileName)))
			return false;
		if (formFile.Length > 10485760)
			return false;
		return true;

	}
}
