using HaNeeStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;


namespace HaNeeStore.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        HaneeStoreContext db = new HaneeStoreContext();
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {

            var username = HttpContext.Session.GetString("Username");
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            return View(user);
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstsanpham = db.Products.AsNoTracking();
            PagedList<Product> lst = new PagedList<Product>(lstsanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        public IActionResult ThemSanPhamMoi()
        {
            /*ViewBag.CatId = new SelectList(db.Categories.ToList(), "CatId", "Catetogry");*/
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(Product sanPham) 
        {
            if(ModelState.IsValid) 
            {
                db.Products.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(sanPham);
        }

        [Route("SuaSanPham")]
        [HttpGet]
        public IActionResult SuaSanPham(int maSanPham)
        {
            /*ViewBag.CatId = new SelectList(db.Categories.ToList(), "CatId", "Catetogry");*/
            var sanPham = db.Products.Find(maSanPham);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham","HomeAdmin");
            }
            return View(sanPham);
        }


        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(int maSanPham)
        {
            var sanPham = db.Products.Where(x => x.ProductId == maSanPham).FirstOrDefault();
            db.Products.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

        [Route("danhsachtaikhoan")]
        public IActionResult DanhSachTaiKhoan(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lsttaikhoan = db.Users.AsNoTracking();
            PagedList<User> lst = new PagedList<User>(lsttaikhoan , pageNumber , pageSize);
            return View(lst);
        }

        [Route("XoaTaiKhoan")]
        [HttpGet]
        public IActionResult XoaTaiKhoan(string tenTK) 
        {
            var taiKhoan = db.Users.Where(u => u.UserName == tenTK).FirstOrDefault();
            db.Users.Remove(taiKhoan);
            db.SaveChanges();
            return RedirectToAction("DanhSachTaiKhoan","HomeAdmin"); 
        }
    }
}
