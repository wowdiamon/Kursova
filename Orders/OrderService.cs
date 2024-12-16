namespace MyStoreNamespace;

public class OrderService:IOrderService
{
    public OrderRepository Repository { get; set; }

    public OrderService(OrderRepository repository)
    {
        this.Repository = repository;
    }
    
    public void CreateOrder(Order order)
    {
        Repository.CreateOrder(order);
    }

    public List<Order> GetOrders()
    {
        return Repository.GetOrders();
    }

    public Order ReadById(int id)
    {
        return Repository.ReadById(id);
    }

    public void DeleteOrder(int id)
    {
       Repository.Delete(id); 
    }
    public List<Order> GetOrdersByCustomerId(int customerId)
    {
        var orders = GetOrders();
        if (orders == null )
        {
            Console.WriteLine("No orders found for this customer.");
            return new List<Order>();
        }
        Console.WriteLine("Found {0} orders for a customer:", orders.Count);
        return orders.Where(o => o.CustomerId == customerId).ToList();
    }

}