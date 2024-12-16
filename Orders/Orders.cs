namespace MyStoreNamespace
{
    public class Order
    {
        private static readonly Stack<int> ReusableIds = new Stack<int>();
        private int _nextId = 1;
        public int CustomerId { get; }
        public string ProductName { get; }
        
        public int Quantity { get; }
        public decimal Price { get; }
        public int OrderIndex { get; } 
     
        public Order(int customerId,string productName,int quantity, decimal price)
        {
            CustomerId = customerId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            OrderIndex = ReusableIds.Count > 0 ? ReusableIds.Pop() : _nextId++;
        }
    }
}