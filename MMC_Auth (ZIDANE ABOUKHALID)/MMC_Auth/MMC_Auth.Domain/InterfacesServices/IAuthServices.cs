using MMC_Auth.Domain.models;

namespace MMC_Auth.Domain.InterfacesServices;

public interface IAuthServices
{
	Task<AuthModel> RegisterAsync(ResgisterModel resgisterModel);
	Task<AuthModel> RegisterGoogleAsync(ResgisterGoogleModel resgisterGoogleModel);
	Task<AuthModel> LoginAsync(LoginModel Model);
	Task<AuthModel> LoginGoogleAsync(LoginGoogleModel Model);


	Task<string> AddRolesToUser(RolesToUserModel rolesToUserModel);
	Task<bool> ValidationEmail(ValidationEmailModel validationEmailModel);
	Task<VerificationEmailModel> GenerateEmailConfirmationTokenAsync(string id);
	Task<string> GetEmailById(string id);
	Task<int> GetCountUsersAsync();
	Task<bool> CheckVerificationEmailDone(string email);
	Task<userData> GetDataUserByEmailAsync(string Email);
	Task<userData> GetDataUserByIdAsync(string id);

}
