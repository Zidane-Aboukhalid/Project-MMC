using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Domain.models;

public class LoginGoogleModel
{
	[Required]
	public string Email { get; set; }
	[Required]
	public string provaiderName { get; set; }
}
