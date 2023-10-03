using HaNeeStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;

namespace HaNeeStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly HaneeStoreContext db;

        public AccountController(HaneeStoreContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(User user)
        {
            if (ModelState.IsValid)
            {
                var userExists = db.Users.Any(u => u.UserName == user.UserName);
                if (!userExists)
                {
                    db.Add(user);
                    db.SaveChanges();
                    return RedirectToAction(nameof(DangNhap));
                }
                else
                {
                    ModelState.AddModelError("", "Tên người dùng đã tồn tại");
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult DangNhap()
        {
            var username = HttpContext.Session.GetString("Username");
            if (username != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(User user)
        {


            var userExists = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userExists == null)
            {
                ModelState.AddModelError("", "Tên người dùng hoặc mật khẩu không chính xác");
            }
            else
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim("FullName",user.UserName),
                    new Claim(ClaimTypes.Role,user.RoleUser == 1 ? "Admin" : "User")
                };
                var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(
                 CookieAuthenticationDefaults.AuthenticationScheme,
                 new ClaimsPrincipal(claimsIdentity));
                if (userExists.RoleUser == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            return View();
        }



        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(DangNhap));
        }
    }
}
