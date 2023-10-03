using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HaNeeStore.Controllers
{
    public class MuaHangTCController : Controller
    {
        [Authorize()]
        public IActionResult Index()
        {
            return View();
        }
    }
}
