namespace MachineTest.Models
{
    public class CartViewModel
    {
        public List<Items> Items { get; set; }
        public string? Couponcode { get; set; }

        public decimal totalPrice { get; set; }
        public int Freecaps { get; set; }
    }
}
