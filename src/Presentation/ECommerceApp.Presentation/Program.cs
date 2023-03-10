using Autofac;
using Autofac.Extensions.DependencyInjection;
using ECommerceApp.Application.IoC;
using ECommerceApp.Infastructure.Context;
using ECommerceApp.Presentation.Models.SeedDataModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Veri tabanına bağlamak için Context atama yaptığımız kod parçasıdır.
builder.Services.AddDbContext<ECommerceAppDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
});

//Filter yapıyoruz ve tek login controllerına izin vereceğiz.
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
	config.Filters.Add(new AuthorizeFilter(policy));
});



builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
{
    x.LoginPath = "/Login/Login";
    x.Cookie = new CookieBuilder
    {
        Name = "EcommerceCookie",
        SecurePolicy = CookieSecurePolicy.Always,
        HttpOnly = true //Client tarafında cookie görünür oluyor
    };
    x.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    x.SlidingExpiration = false;
    x.Cookie.MaxAge = x.ExpireTimeSpan;
});

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromMinutes(5);
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

///Program.cs çalıştırıldığında veri tabanında veri yoksa veri atama sağlayabileceğimiz bir SeedData static sınıfı oluşturuldu.
SeedData.Seed(app);

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();//wwwroot

app.UseRouting();

app.UseAuthorization();

//Area var ise bu metod kullanılır.
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
