using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MachineTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            Products prod = new Products();
        }
        
        [HttpPost,HttpGet]
        public IActionResult Index(Products products)
        {
            products.Tshirts = 6;
            products.Jeans = 8;
            products.Shoes = 4;
            products.Caps = 20;
            //Products products = new Products();
            var cartItems = new List<Items>
            {
                new Items { ItemName = "T-shirt", ItemPrice = (2000*products.Tshirts), Quantity = products.Tshirts },
                new Items { ItemName = "Jeans", ItemPrice = (4000*products.Jeans), Quantity = products.Jeans },
                new Items { ItemName = "Shoes", ItemPrice = (6000*products.Shoes), Quantity = products.Shoes },
                new Items { ItemName = "Cap", ItemPrice = (2000*products.Caps), Quantity = products.Caps }
            };
            int total = 0;
            foreach(var item in cartItems)
            {
                 total =Convert.ToInt32( total+ item.ItemPrice);
            }
            

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
