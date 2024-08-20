using MachineTest.Models;

namespace MachineTest.Middleware
{
    public class CouponMiddlware
    {
        private readonly IMiddleware _middleware;

        public CouponMiddlware(IMiddleware middleware)
        {
            _middleware = middleware;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            var couponcode = context.Request.Query["Coupon"];
            if (!string.IsNullOrEmpty(couponcode))
            {
                ApplycouponDiscount(context, couponcode);
            }
            //await _middleware(context);
        }

        private void ApplycouponDiscount(HttpContext context, string couponcode)
        {
            var cartItems = new List<Items>
            {
                new Items { ItemName = "T-shirt", ItemPrice = 2000, Quantity = 6 },
                new Items { ItemName = "Jeans", ItemPrice = 4000, Quantity = 8 },
                new Items { ItemName = "Shoes", ItemPrice = 6000, Quantity = 4 },
                new Items { ItemName = "Cap", ItemPrice = 2000, Quantity = 20 }
            };

           if (couponcode == "CDPCAP" )
            {
                var Jeans = cartItems.FirstOrDefault(i => i.ItemName == "Jeans");
                var Cap = cartItems.FirstOrDefault(i => i.ItemName == "Cap");


                if(Jeans != null && Cap != null && Jeans.Quantity >=2)
                {
                    Cap.Quantity -= 1;
                }

            }
            context.Items["cartItems"]= cartItems;

        }

         
    }
}
