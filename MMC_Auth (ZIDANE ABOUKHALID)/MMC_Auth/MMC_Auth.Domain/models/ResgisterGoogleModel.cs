using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC_Auth.Domain.models;

public class ResgisterGoogleModel
{
	[Required, MaxLength(100)]
	public string fullName { get; set; }
	[Required, MaxLength(50)]
	public string Username { get; set; }
	[Required, MaxLength(120)]
	public string Email { get; set; }

}
