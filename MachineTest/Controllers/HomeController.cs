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

            ViewData["CartItems"] = cartItems;
                    float totalprice = 0;
            float totalamount =0;
            float discount =10;
          foreach (var item in cartItems)
               


            {
                if (item.ItemName == "Jeans") {
                   float  price = item.ItemPrice / item.Quantity;

                    item.Quantity = item.Quantity / 2;

                    item.ItemPrice = price * item.Quantity;
                    


                 }
                totalprice = totalprice + item.ItemPrice;
                totalamount = totalamount +(item.ItemPrice * discount / 100);
               // totalprice  = totalamount



            }
          totalprice = totalprice -totalamount;
            ViewData["Total"] = totalprice;

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
