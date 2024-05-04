using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multishop.WebDTO.DTOs.IdentityDtos
{
	public class RegisterDto
	{
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		[Compare("Password",ErrorMessage ="Passwords do not match.")]
		public string ConfirmPassword { get; set; }
	}
}
