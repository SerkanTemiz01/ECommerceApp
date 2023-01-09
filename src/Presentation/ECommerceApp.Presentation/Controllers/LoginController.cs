﻿
using ECommerceApp.Application.Models.DTOs;
using ECommerceApp.Application.Services.LoginService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace ECommerceApp.Presentation.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService= loginService;    
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loggedUSer = await _loginService.Login(loginDTO);
            if(loggedUSer != null)
            {
                var jsonUser = JsonConvert.SerializeObject(loggedUSer);

                HttpContext.Session.SetString("loggedUser", jsonUser);

                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Role, loggedUSer.Roles.ToString()));

                var userIdentity=new ClaimsIdentity(claims,"Login");

                ClaimsPrincipal principal=new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal);

                if(loggedUSer.Roles==Domain.Enums.Roles.Admin)
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }
                if (loggedUSer.Roles == Domain.Enums.Roles.Manager)
                {
                    return RedirectToAction("Index", "Home", new { area = "Manager" });
                }
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.Response.Cookies.Delete(CookieAuthenticationDefaults.AuthenticationScheme);
                
            }
            

            return View(loginDTO);
        }

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login");
		}
	}
}
