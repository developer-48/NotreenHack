using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using GoodChildren.Models;
using GoodChildren.ViewModels;

namespace GoodChildren.Controllers
{
    public class AccountController : Controller
    {
        private UserContext db;
        public AccountController(UserContext context)
        {
            db = context;
        }
        public IActionResult Autorithe()
        {
            return View();
        }
        public IActionResult Home()
        {
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.LoginEmail == model.Email && u.Password == model.Password);
                Spons userS = await db.Sponsers.FirstOrDefaultAsync(u => u.LoginEmail == model.Email);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }else if (userS != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.LoginEmail == model.Email);
                Spons userS = await db.Sponsers.FirstOrDefaultAsync(u => u.LoginEmail == model.Email);
                if (user == null&&userS==null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User { LoginEmail = model.Email, Password = model.Password, BirthDate = model.BirthDate, cityChillHouse = model.cityChillHouse, fullName= model.fullName,
                    PhoneNum= model.PhoneNum, Role=model.Role, Coins=250});
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        public async Task<IActionResult> RegisterS(RegisteSmodel model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.LoginEmail == model.Email);
                Spons userS = await db.Sponsers.FirstOrDefaultAsync(u => u.LoginEmail == model.Email);
                if (user == null && userS == null)
                {
                    // добавляем пользователя в бд
                    db.Sponsers.Add(new Spons
                    {
                        LoginEmail = model.Email,
                        Password = model.Password,
                        BirthDate = model.BirthDate,
                        cityChillHouse = model.cityChillHouse,
                        fullName = model.fullName,
                        PhoneNum = model.PhoneNum,
                        Role = model.Role,
                        OSebe = model.OSebe
                    });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
