using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Models.VMs
{
    public class UpdateManagerVM
    {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Roles Roles { get; set; } = Roles.Manager;

        [NotMapped]
        public IFormFile UploadPath { get; set; }
        public string? ImagePath { get; set; }
        public DateTime? UpdateDate { get; set; }=DateTime.Now;
        public Status Status { get; set; } = Status.Modified;

    }
}
