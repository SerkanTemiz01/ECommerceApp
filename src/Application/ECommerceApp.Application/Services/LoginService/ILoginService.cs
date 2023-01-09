using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Services.LoginService
{
    public interface ILoginService
    {
        Task<Employee> Login(LoginDTO loginDTO);
    }
}
