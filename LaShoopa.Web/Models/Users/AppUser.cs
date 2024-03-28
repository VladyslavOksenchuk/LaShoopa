using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LaShoopa.Web.Models.Users
{
	public class AppUser : IdentityUser
	{
		[Required]
        public string Name { get; set; }

		[Required]
		public string Surname { get; set; }
    }
}
