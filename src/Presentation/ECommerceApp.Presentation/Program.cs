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

//Veri taban�na ba�lamak i�in Context atama yapt���m�z kod par�as�d�r.
builder.Services.AddDbContext<ECommerceAppDbContext>(_ =>
{
    _.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
});

//Filter yap�yoruz ve tek login controller�na izin verece�iz.
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
        HttpOnly = true //Client taraf�nda cookie g�r�n�r oluyor
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

///Program.cs �al��t�r�ld���nda veri taban�nda veri yoksa veri atama sa�layabilece�imiz bir SeedData static s�n�f� olu�turuldu.
SeedData.Seed(app);

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();//wwwroot

app.UseRouting();

app.UseAuthorization();

//Area var ise bu metod kullan�l�r.
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
