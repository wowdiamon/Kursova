namespace MyStoreNamespace;

public interface IOrderService
{
    void CreateOrder(Order order);
    List<Order> GetOrders();
    Order ReadById(int id);
    void DeleteOrder(int id);
    List<Order> GetOrdersByCustomerId(int customerId);
}