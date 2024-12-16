namespace MyStoreNamespace;

public class AddProduct : ICommands
{
    private readonly ProductService _productService;

    public AddProduct(ProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Add New Product ===");
        
        Console.Write("Enter product name: ");
        string name = Console.ReadLine();

        Console.Write("Enter product price: ");
        decimal price;
        while (!decimal.TryParse(Console.ReadLine(), out price) || price <= 0)
        {
            Console.WriteLine("Invalid price. Please enter a valid price.");
        }
      
        
        Product newProduct = new Product (name, price);
        _productService.AddProduct(newProduct);

    
        var products = _productService.showAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($" ProductId : {product.ProductID} Product name : {product.ProductName}");
        }
        Console.WriteLine("Product added successfully!");
        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Add product";
    }
}