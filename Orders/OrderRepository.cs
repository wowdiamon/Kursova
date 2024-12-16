namespace MyStoreNamespace;

public class OrderRepository:IOrderRepository
{
    public DbContext Context { get; set; }
         
    public OrderRepository(DbContext Context)
    {
        this.Context = Context;
    }

    public void CreateOrder(Order order)
    {
        Context.Orders.Add(order);
    }

    public List<Order> GetOrders()
    {
        var orders = Context.Orders;
        return orders == null ? new List<Order>() : orders; 
    }


    public Order ReadById(int id)
    {
        return Context.Orders.FirstOrDefault(o=>o.OrderIndex==id);
    }

    public void Delete(int id)
    {
        Context.Orders.Remove(ReadById(id));
    }
}