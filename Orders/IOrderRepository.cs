namespace MyStoreNamespace;

public interface IOrderRepository
{
    void CreateOrder(Order order);
    List<Order> GetOrders();
    Order ReadById(int id);
    void Delete(int id);
}