using ECommerceApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Domain.Entities
{
    public class Mall:IBaseEntity
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Status Status { get; set; }

        public Mall()
        {
            Employees = new List<Employee>();
        }
    }
}
