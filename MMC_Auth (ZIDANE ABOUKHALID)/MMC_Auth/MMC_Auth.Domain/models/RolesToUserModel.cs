using System.ComponentModel.DataAnnotations;


namespace MMC_Auth.Domain.models
{
	public class RolesToUserModel
	{
		[Required]
        public string Id{ get; set; }
		[Required]
		public string Role { get; set; }
    }
}
