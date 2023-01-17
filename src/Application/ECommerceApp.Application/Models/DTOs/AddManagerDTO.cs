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
    public class AddManagerDTO
    {
        public Guid ID =>Guid.NewGuid();

        [Required(ErrorMessage ="Cannot be Empty!!!")]
        [MaxLength(25,ErrorMessage ="You cannot enter more than 25 chracters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Can not be Empty!!!")]
        [MaxLength(50, ErrorMessage = "You cannot enter more than 50 chracters")]
        public string Surname { get; set; }
        public Roles Roles => Roles.Manager;
        public DateTime CreateDate => DateTime.Now;
        public Status Status => Status.Active;

        public string EmailAddress { get; set; }
        public string Password { get; set; }

        [BirthDateExtension(ErrorMessage="\r\nThe age of the employee must be over 18")]
        public DateTime BirthDate { get; set; }


        public string? ImagePath { get; set; }

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }

    }
}
