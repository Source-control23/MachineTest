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

            //var total = 0;
            var total = cartItems.Sum(item => item.ItemPrice * item.Quantity);

            // Pass the cart items and total to the view
            ViewData["CartItems"] = cartItems;
            ViewData["Total"] = total;


            ViewData["CartItems"] = cartItems;
            ViewData["Total"] = total;

            string coup = "CDP10";
            string secCou = "CDPCAP";

            var discount = total;
            var calculateDiscount = Convert.ToInt32(discount / 100);

            var myDic = calculateDiscount;


            // With Discount 
            if (cpon == coup)
            {
                myDic


            }

            else if (cpon == secCou)
            {
                // second code chek two item 


            }
            else
            {
                // Without Any Discount Here
                
            }


            //if (!string.IsNullOrEmpty(this.cp.Text.ToString()))
            //{
            //    actualPrice = Convert.ToDecimal(this.numericTextBox3.Text);
            //}

            //else
            //{
            //    numericTextBox3.Text = "";
            //}

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
