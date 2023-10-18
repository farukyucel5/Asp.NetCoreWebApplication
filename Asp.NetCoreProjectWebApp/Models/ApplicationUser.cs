using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetCoreProjectWebApp.Models
{
	public class ApplicationUser:IdentityUser
	{
		[Required]
		public int Ogrencino {  get; set; }

		public string Adres {  get; set; }

		public string Fakülte { get; set; }

		public string Bolum { get; set; }


	}
}
