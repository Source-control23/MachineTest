namespace MachineTest.Models
{
    public class ShoppingCart
    {
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public int Quantity { get; set; }
        public string ItemName { get; set; }
        public float ItemPrice { get; set; }
    }
}
