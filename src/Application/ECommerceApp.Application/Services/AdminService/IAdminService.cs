using AutoMapper;
using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Application.Services.AdminService
{
    public interface IAdminService
    {
        Task CreateManager(ApiAddManagerDTO apiAddManagerDTO);

        Task<List<ListOfManagerVM>> GetManagers();

         Task<UpdateManagerDTO> GetManager(Guid id);
        Task UpdateManager(UpdateManagerDTO updateManagerDTO);
        Task DeleteMAnager(Guid id);
        Task<ApiAddManagerDTO> GetApiManagerDTO(AddManagerDTO addManagerDTO);

	}
}
