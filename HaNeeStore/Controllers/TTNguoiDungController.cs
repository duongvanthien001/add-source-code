using HaNeeStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaNeeStore.Controllers
{
    [Authorize()]
    public class TTNguoiDungController : Controller
    {
        HaneeStoreContext db = new HaneeStoreContext();
        public IActionResult ThongTinNguoiDung()
        {
            var username = HttpContext.User.Identity?.Name;
            var userList = HttpContext.User.Claims.ToList();
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            return View(user);
        }
        
        [Route("SuaThongTin")]
        [HttpGet]
        public IActionResult SuaThongTin(string tenTK)
        {
            var taiKhoan = db.Users.Find(tenTK);
            return View(taiKhoan);
        }
        [Route("SuaThongTin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaThongTin(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(ThongTinNguoiDung));
            }
            return View(user);
        }
        
    }
}
