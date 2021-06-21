using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace LibraryWebUI.Controllers
{
    [Authorize(Roles = "User")]
    public class CartController : Controller
    {
        private readonly IBookService _bookService;
        public CartController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult AddToCart(int? bookId)
        {
            if (bookId == null)
                return View("NotFound");
            var book = _bookService.Query().SingleOrDefault(p => p.Id == bookId.Value);
            string userId = User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.Sid).Value;
            List<CartModel> cart = new List<CartModel>();
            CartModel cartItem;
            string cartJson;

       
            if (HttpContext.Session.GetString("cart") != null)
            {
                cartJson = HttpContext.Session.GetString("cart");
                cart = JsonConvert.DeserializeObject<List<CartModel>>(cartJson);
            }
            cartItem = new CartModel()
            {
                BookId = bookId.Value,
                UserId = Convert.ToInt32(userId),
                BookName = book.Name,
                UnitPrice = book.UnitPrice
            };
            cart.Add(cartItem);
            cartJson = JsonConvert.SerializeObject(cart);
            HttpContext.Session.SetString("cart", cartJson);

            return RedirectToAction("Index", "Books", new { message = book.Name + " added to cart.", id = book.Id });
        }
        public IActionResult Index()
        {
            List<CartModel> cart = new List<CartModel>();
            if (HttpContext.Session.GetString("cart") != null)
            {
                cart = JsonConvert.DeserializeObject<List<CartModel>>(HttpContext.Session.GetString("cart"));
            }

            List<CartGroupByModel> cartGroupBy = cart.GroupBy(
              
                c => new { c.BookId, c.UserId, c.BookName }
                ).Select(cGroupBy => new CartGroupByModel()
                {
                    BookId = cGroupBy.Key.BookId,
                    UserId = cGroupBy.Key.UserId,
                    BookName = cGroupBy.Key.BookName,
                    TotalUnitPriceText = "$" + cGroupBy.Sum(cgb => cgb.UnitPrice).ToString(new CultureInfo("en")),
                    TotalCount = cGroupBy.Count()
                }).ToList();
            cartGroupBy = cartGroupBy.OrderBy(cgb => cgb.BookName).ToList();

            return View(cartGroupBy);
        }
        public IActionResult ClearCart()
        {
            HttpContext.Session.Remove("cart");
            TempData["CartMessage"] = "Cart cleared";
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveFromCart(int? productId, int? userId)
        {
            if (productId == null || userId == null)
                return View("NotFound");
            CartModel item = null;
            if (HttpContext.Session.GetString("cart") != null)
            {
                List<CartModel> cart = JsonConvert.DeserializeObject<List<CartModel>>(HttpContext.Session.GetString("cart"));
                item = cart.FirstOrDefault(c => c.BookId == productId.Value && c.UserId == userId.Value);
                if (item != null)
                    cart.Remove(item);
                HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            }
            if (item != null)
                TempData["CartMessage"] = item.BookName + " removed from cart";
            return RedirectToAction(nameof(Index));
        }

    }
}
