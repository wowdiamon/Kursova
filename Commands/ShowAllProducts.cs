namespace MyStoreNamespace;

public class ShowAllProducts : ICommands
{
    private readonly ProductService _productService;

    public ShowAllProducts(ProductService productService)
    {
        _productService = productService;
    }

    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== List of all products ===");
        var products = _productService.showAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($"ProductId : {product.ProductID} Product Name : {product.ProductName} Product price : {product.Price} Product quantity : {product.Quantity}");
        }

        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Show all products";
    }
}