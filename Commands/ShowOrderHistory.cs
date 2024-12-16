namespace MyStoreNamespace;

public class ShowOrderHistory : ICommands
{
    private readonly AccountService _accountService;
    private readonly OrderService _orderService;

    public ShowOrderHistory(AccountService accountService, OrderService orderService)
    {
        _accountService = accountService;
        _orderService = orderService;
    }

    public void Execute()
    {
        var account = Program.currentLoggedInUser;
        var orders = _orderService.GetOrdersByCustomerId(account.Id);

        if (orders == null) 
        {
            Console.WriteLine("No orders found for the current user.");
        }
        else
        {
            Console.WriteLine("=== Order History ===");
            foreach (var order in orders)
            {
                Console.WriteLine($"Product: {order.ProductName}, Quantity: {order.Quantity}, Price: {order.Price}");
            }
        }

        Console.ReadKey();
    }



    public string GetInfo()
    {
        return "Show order history";
    }
}