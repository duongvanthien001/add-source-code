using HaNeeStore.Extensions;
using HaNeeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HaNeeStore.Controllers
{
    public class CartController : Controller
    {
        private readonly HaneeStoreContext db;
        public CartController(HaneeStoreContext _db)
        {
            db = _db;
        }
        
        public IActionResult Index()
        {
            Cart cart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            return View(cart);
        }
        
        [HttpGet("/Cart/AddToCart/{productId}")]
        public IActionResult AddToCart(int productId, string? quantityString)
        {
            int quantity = !String.IsNullOrEmpty(quantityString) ? Int32.Parse(quantityString) : 1;

            Cart cart = HttpContext.Session.GetObject<Cart>("Cart") ?? new Cart();
            var product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product != null) {
                int cartIndex = cart.CartItems.FindIndex(c => c.ProductId == productId);
                if (cartIndex == -1) {
                    cart.CartItems.Add(new CartItem { ProductId = productId,ProductName = product.ProductName,Price = product.Price ?? 0,Image= product.ProductPhoto,Quantity = quantity});
                } else
                {
                    cart.CartItems[cartIndex].Quantity += quantity;
                }

                cart.Count += quantity;
                cart.SubTotal += product.Price ?? 0 * quantity;
                HttpContext.Session.SetObject("Cart",cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult UpdateCart(Guid id, string? quantityString)
        {
            Cart? cart = HttpContext.Session.GetObject<Cart>("Cart");
            if (cart != null && !String.IsNullOrEmpty( quantityString))
            {
                int quantity = Int32.Parse(quantityString);
                int cartIndex = cart.CartItems.FindIndex(c => c.Id == id); 
                if (cartIndex != -1)
                {
                    cart.Count -= cart.CartItems[cartIndex].Quantity;
                    cart.SubTotal -= cart.CartItems[cartIndex].SubTotal;
                    cart.CartItems[cartIndex].Quantity = quantity;
                    cart.Count += quantity;
                    cart.SubTotal += cart.CartItems[cartIndex].SubTotal;
                    HttpContext.Session.SetObject("Cart", cart);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCart(Guid id)
        {
            var cart = HttpContext.Session.GetObject<Cart>("Cart");
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(c => c.Id == id);
                if (cartItem != null)
                {
                    cart.Count -= cartItem.Quantity;
                    cart.SubTotal -= cartItem.SubTotal;
                    cart.CartItems.Remove(cartItem);
                    HttpContext.Session.SetObject("Cart", cart);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index","MuaHangTC");
        }
        
    }

}

