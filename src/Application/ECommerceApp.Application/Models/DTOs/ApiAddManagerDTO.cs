using ECommerceApp.Application.Extensions;
using ECommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Models.DTOs
{
	public class ApiAddManagerDTO
	{
		public Guid ID { get; set; }
		public string Name { get; set; }	
		public string Surname { get; set; }
		public Roles Roles { get; set; }
		public DateTime CreateDate { get; set; }
		public Status Status { get; set; }
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public DateTime BirthDate { get; set; }
		public string? ImagePath { get; set; }

	}
}
