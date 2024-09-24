using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace MachineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<Items> GetproductList()
        {

            var cartItems = new List<Items>
            {
                new Items { ItemName = "T-shirt", ItemPrice = 2000, Quantity = 6 },
                new Items { ItemName = "Jeans", ItemPrice = 4000, Quantity =8  },
                new Items { ItemName = "Shoes", ItemPrice = 6000, Quantity = 4 },
                new Items { ItemName = "Cap", ItemPrice = 2000, Quantity = 20 }

            };

            return cartItems;
        }


        public IActionResult Index()
        {
            
          var cartItems= GetproductList();

            ViewData["CartItems"] = cartItems;


            return View();
        }

        public IActionResult ApplyCoupon(string couponcode)
        {

            var cartItems = GetproductList();

            var model = new CartViewModel
            {
                Items = cartItems,
                Couponcode = couponcode,
                totalPrice = CalculateTotalPrice(cartItems, couponcode)
            };


            return View(model);
        }


        private decimal CalculateTotalPrice(List<Items> items , string couponcode)
        {
            decimal total = items.Sum(p=>p.ItemPrice);

            if(couponcode!.ToUpper() == "CDP10")
            {
                total *= 0.90m;
                ViewData["Total"] = total;
            }
            if (couponcode!.ToUpper() == "CDPCAP" && items.Count(p =>p.isJeans) >=2)
            {
                total -= 10;
                ViewData["Total"] = total;
            }

            return total;
             

            //return RedirectToAction("Index");
        }

      


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
