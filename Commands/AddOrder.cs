namespace MyStoreNamespace;

public class AddOrder : ICommands
{
    private readonly AccountService _accountService;
    private readonly OrderService _orderService;
    private readonly ProductService _productService;

    public AddOrder(AccountService accountService, OrderService orderService, ProductService productService)
    {
        _accountService = accountService;
        _orderService = orderService;
        _productService = productService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Place Order ===");
        var products = _productService.showAllProducts();
        foreach (var produc in products)
        {
            Console.WriteLine($"{produc.ProductID}. {produc.ProductName}, Price: {produc.Price}, Quantity: {produc.Quantity}");
        }
        Console.Write("Enter product ID: ");
        int productId = int.Parse(Console.ReadLine());
        

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        var product = _productService.ReadById(productId);

        decimal totalPrice = product.Price * quantity;

        if (Program.currentLoggedInUser.Balance < totalPrice)
        {
            Console.WriteLine("Insufficient balance.");
            Console.ReadKey();
            return;
        }

        if (product.Quantity < quantity)
        {
            Console.WriteLine("Not enough product in stock.");
            Console.ReadKey();
            return;
        }
        
        Program.currentLoggedInUser.Balance -= totalPrice;
        
        _productService.ChangeQuantity(productId, product.Quantity - quantity);
        
        Order newOrder = new Order(Program.currentLoggedInUser.Id, product.ProductName, quantity, totalPrice);
        _orderService.CreateOrder(newOrder);

        Console.WriteLine("Order placed successfully.");
        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Place an order";
    }
}