using SharedModels;

namespace Producer.Data
{
    public class Purchase: IPurchaseCreated
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
