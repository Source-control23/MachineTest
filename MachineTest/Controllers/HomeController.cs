using MachineTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

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
            var total = 0;
            string cuponcode = String.Empty;
            int jeans = 0;
           
            foreach(var item in cartItems)
            {
                total = total + (int)item.ItemPrice;
                if (cuponcode == "CDPCAP")
                {
                        if (item.ItemName == "Jeans")
                        {
                            jeans = item.Quantity / 2;
                        }
                        if (item.ItemName == "Cap")
                        {
                            item.Quantity = item.Quantity + jeans;
                        }
                }
            }
            if (cuponcode == "CDPA10")
            {

                total = total * (int)0.1;
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
