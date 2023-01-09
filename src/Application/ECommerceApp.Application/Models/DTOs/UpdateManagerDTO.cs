using ECommerceApp.Application.Extensions;
using ECommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Models.DTOs
{
    public class UpdateManagerDTO
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Cannot be Empty!!!")]
        [MaxLength(25, ErrorMessage = "You cannot enter more than 25 chracters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Can not be Empty!!!")]
        [MaxLength(50, ErrorMessage = "You cannot enter more than 50 chracters")]
        public string Surname { get; set; }
        public Roles Roles { get; set; } = Roles.Manager;

        [PictureFileExtension]
        public IFormFile UploadPath { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
        public Status Status { get; set; } = Status.Modified;
    }
}
