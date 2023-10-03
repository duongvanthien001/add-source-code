using HaNeeStore.Models;
using HaNeeStore.Resposition;
using Microsoft.AspNetCore.Mvc;
namespace HaNeeStore.ViewComponents
{
    public class LoaiSPmenuViewComponent : ViewComponent
    {
        private readonly ILoaiSP _loaiSPwC;
        public LoaiSPmenuViewComponent(ILoaiSP loaiSP)
        {
            _loaiSPwC = loaiSP;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSPwc = _loaiSPwC.GetAllCat();
            return View(loaiSPwc);
        }
    }
}
