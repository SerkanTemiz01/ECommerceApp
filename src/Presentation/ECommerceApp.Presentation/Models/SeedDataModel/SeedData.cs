using ECommerceApp.Domain.Entities;
using ECommerceApp.Domain.Enums;
using ECommerceApp.Infastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.Presentation.Models.SeedDataModel
{
    public static class SeedData
    {

        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ECommerceAppDbContext>();
            dbContext.Database.Migrate();

            if (dbContext.Categories.Count() == 0)
            {
                dbContext.Categories.Add(new Category()
                {
                    ID = Guid.NewGuid(),
                    Name = "Home Appliances",                
                    Status = Status.Active,
                    CreateDate = DateTime.Now,                  
                });

            }
            if (dbContext.Categories.Count() == 0)
            {
                dbContext.Categories.Add(new Category()
                {
                    ID = Guid.NewGuid(),
                    Name = "Electronics",
                    Status = Status.Active,
                    CreateDate = DateTime.Now,
                });

            }
            if (dbContext.Categories.Count() == 0)
            {
                dbContext.Categories.Add(new Category()
                {
                    ID = Guid.NewGuid(),
                    Name = "Textile",
                    Status = Status.Active,
                    CreateDate = DateTime.Now,
                });

            }
            if (dbContext.Employees.Count() == 0)
            {
                dbContext.Employees.Add(new Employee()
                {
                    ID = Guid.NewGuid(),
                    Name = "Serkan",
                    Surname = "Temiz",
                    EmailAddress = "serkan_154.gs@hotmail.com",
                    Status = Status.Active,
                    CreateDate = DateTime.Now,
                    Password="1234",
                    Roles = Roles.Admin,
                    BirthDate= new DateTime(1995,05,09)
                });

            }
            dbContext.SaveChanges();
        }
    }
}

