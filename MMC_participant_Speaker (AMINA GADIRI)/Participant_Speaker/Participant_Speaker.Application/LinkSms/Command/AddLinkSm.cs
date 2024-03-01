using MediatR;


namespace Participant_Speaker.Application.LinkSms.Command
{
	public record AddLinkSm(Guid SpeakerId, string Url, string Type) :IRequest<int>;
}
