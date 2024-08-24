using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace MachineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var cartItems = new List<Items>
            {
                new Items { ItemName = "T-shirt", ItemPrice = 2000, Quantity = 6 },
                new Items { ItemName = "Jeans", ItemPrice = 4000, Quantity = 8 },
                new Items { ItemName = "Shoes", ItemPrice = 6000, Quantity = 4 },
                new Items { ItemName = "Cap", ItemPrice = 2000, Quantity = 20 }
            };

            decimal resultTotalAmount = 0;
            string coupancode = "CDPCAP";
            if (coupancode == "CDPCAP")
            {
                if (cartItems.Count > 0)
                {
                    foreach (var item in cartItems)
                    {
                        if (item.ItemName == "Jeans" && item.Quantity == 2)
                        {
                            Console.WriteLine("One cap is free");
                        }
                       
                    }
                }
            }
            string coupancode2 = "CDP10";
            if (coupancode2 == "CDP10")
            {
                decimal markdown;
                decimal discountedPrice;
                foreach (var item in cartItems)
                {
                    //  10% of discount 
                    markdown = Math.Round(item.ItemPrice * (10 / 100m), 2, MidpointRounding.ToEven);
                    // discount amout 
                    discountedPrice = item.ItemPrice - markdown;
                    resultTotalAmount += discountedPrice;

                }
            }
           
                    //var calculateDiscount = Convert.ToInt32(item.ItemPrice / 100);

            

            

            /*return discountedPrice*/;

            var total = resultTotalAmount;

            ViewData["CartItems"] = cartItems;
            ViewData["Total"] = total;

            return View();
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
