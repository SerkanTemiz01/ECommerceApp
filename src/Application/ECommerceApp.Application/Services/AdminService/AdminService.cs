using AutoMapper;
using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Models.VMs;
using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using ECommerceApp.Domain.Repositories;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerceApp.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepo _employeeRepo;

        public AdminService(IMapper mapper, IEmployeeRepo employeeRepo)
        {
            _mapper = mapper;
            _employeeRepo = employeeRepo;
        }

        public async Task CreateManager(AddManagerDTO addManagerDTO)
        {
            var addEmployee=_mapper.Map<Employee>(addManagerDTO);
            if(addEmployee.UploadPath!= null) 
            {
                using var image = Image.Load(addManagerDTO.UploadPath.OpenReadStream());

                image.Mutate(x=>x.Resize(600,560)); //Resim boyutu ayarladık;

                Guid guid= Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");

                addEmployee.ImagePath = $"/images/{guid}.jpg";
                await _employeeRepo.Create(addEmployee);
            }
            else
            {
                addEmployee.ImagePath = $"/images/default.jpeg";
                await _employeeRepo.Create(addEmployee);
            }
            
        }

        public async Task<List<ListOfManagerVM>> GetManagers()
        {
            var managers = await _employeeRepo.GetFilteredList(
                select: x => new ListOfManagerVM
                {
                    ID = x.ID,
                    Name = x.Name,
                    Surname = x.Surname,
                    Roles = x.Roles,
                    ImagePath=x.ImagePath
                },where :x=>((x.Status==Status.Active||x.Status==Status.Modified)&&x.Roles==Roles.Manager),
                orderBy :x=>x.OrderBy(x=>x.Name));
            return managers;
        }

        public async Task<UpdateManagerDTO> GetManager(Guid id)
        {
            var manager = await _employeeRepo.GetFilteredFirstOrDefault(
                select: x => new UpdateManagerVM
                {
                    ID = x.ID,
                    Name = x.Name,
                    Surname = x.Surname,
                    Roles = x.Roles,
                    ImagePath = x.ImagePath,

                }, where: x => x.ID == id);
            var updateManagerDTO=_mapper.Map<UpdateManagerDTO>(manager);
            return updateManagerDTO;
        }
        public async Task UpdateManager(UpdateManagerDTO updateManagerDTO)
        {
            var model = await _employeeRepo.GetDefault(x => x.ID == updateManagerDTO.ID);

            model.Name= updateManagerDTO.Name;
            model.Surname= updateManagerDTO.Surname;
            model.ImagePath= updateManagerDTO.ImagePath;
            model.Status=updateManagerDTO.Status;
            model.UpdateDate= updateManagerDTO.UpdateDate;

            using var image = Image.Load(updateManagerDTO.UploadPath.OpenReadStream());

            image.Mutate(x => x.Resize(600, 560)); //Resim boyutu ayarladık;

            Guid guid = Guid.NewGuid();
            image.Save($"wwwroot/images/{guid}.jpg");

            updateManagerDTO.ImagePath = $"/images/{guid}.jpg";
            await _employeeRepo.Update(model);
        }

        public async Task DeleteMAnager(Guid id)
        {
            var model= await _employeeRepo.GetDefault(x=>x.ID== id);    
            model.DeleteDate= DateTime.Now;
            model.Status = Status.Passive;

            await _employeeRepo.Delete(model);
        }
    }
}
