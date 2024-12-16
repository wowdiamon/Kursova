namespace MyStoreNamespace;

public class UpdateProduct : ICommands
{
    private readonly ProductService _productService;

    public UpdateProduct(ProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Update Product ===");
        var products = _productService.showAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($" ProductId : {product.ProductID} Product name : {product.ProductName}");
        }
        Console.Write("Enter product ID to update: ");
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int productId))
        {
            Console.WriteLine("Invalid product ID.");
            Console.ReadKey();
            return;
        }
        Console.Write($"Enter new name : ");
        string newName = Console.ReadLine();
        Console.Write($"Enter new price : ");
        decimal newPrice;
        while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice <= 0)
        {
            Console.WriteLine("Invalid price. Please enter a valid price.");
        }
        Console.Write("Enter product quantity: ");
        string iquantity = Console.ReadLine();
        int quantity;
        while (!int.TryParse(iquantity, out quantity) && quantity> 0)
        {
            
            Console.WriteLine("Invalid input. Please enter a valid quantity greater than 0.");
        }

        
        _productService.UpdateProduct(productId,newName,newPrice);
        _productService.ChangeQuantity(productId,quantity);
        Console.WriteLine("Product updated successfully!");
        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Update product";
    }
}