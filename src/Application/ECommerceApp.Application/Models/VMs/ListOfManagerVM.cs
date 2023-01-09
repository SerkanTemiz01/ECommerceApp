using ECommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Models.VMs
{
    public class ListOfManagerVM
    {
        public Guid ID { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }

        public Roles Roles { get; set; }
        public string ImagePath { get; set; }
    }
}
