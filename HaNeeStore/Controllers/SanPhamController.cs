using HaNeeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;


namespace HaNeeStore.Controllers
{
    public class SanPhamController : Controller
    {
        HaneeStoreContext db = new HaneeStoreContext();
        public IActionResult Index(int? page)
        {
            int pageSize = 6;
            int pageNumber = page == null || page < 0 ? 1:page.Value ;
            var lstsanpham =db.Products.AsNoTracking();
            PagedList<Product> lst=new PagedList<Product>(lstsanpham,pageNumber,pageSize);
            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(int maloai)
        {
            List<Product> lstdanhmuc=db.Products.Where(x=>x.CatId==maloai).ToList();
            return View(lstdanhmuc);
        }

        public IActionResult ChiTietSanPham (int maSp , string maaSP)
        {
            var sanpham = db.Products.SingleOrDefault(x => x.ProductId == maSp);
            var anhsanpham = db.Products.Where(x=>x.ProductPhoto== maaSP).ToList();
            ViewBag.anhsanpham=anhsanpham;
            return View(sanpham);
        }

        public IActionResult Search(string search)
        {
            List<Product> products = GetProduct(search);
            return View("Search",products);
        }

        private List<Product> GetProduct(string search)
        {
            var products = db.Products.Where(p => p.ProductName.ToLower().Contains(search.ToLower())).ToList();    
            return products;
        }
    }
}
