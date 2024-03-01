using Microsoft.AspNetCore.Identity;


namespace MMC_Auth.Domain.Entitys
{
	public class User : IdentityUser
	{
        public string FullName { get; set; }
    }
}
