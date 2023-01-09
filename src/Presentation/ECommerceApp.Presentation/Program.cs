using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerceApp.Application.IoC;
using ECommerceApp.Infastructure.Context;
using ECommerceApp.Presentation.Models.SeedDataModel;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veri tabanýna baðlamak için Context atama yaptýðýmýz kod parçasýdýr.
builder.Services.AddDbContext<ECommerceAppDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new DependencyResolver());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

///Program.cs çalýþtýrýldýðýnda veri tabanýnda veri yoksa veri atama saðlayabileceðimiz bir SeedData static sýnýfý oluþturuldu.
SeedData.Seed(app);


app.UseHttpsRedirection();
app.UseStaticFiles();//wwwroot

app.UseRouting();

app.UseAuthorization();

//Area var ise bu metod kullanýlýr.
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
