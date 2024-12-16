namespace MyStoreNamespace;

public class DeleteProduct : ICommands
{
    private readonly ProductService _productService;

    public DeleteProduct(ProductService productService)
    {
        _productService = productService;
    }
    public void Execute()
    {
        Console.Clear();
        Console.WriteLine("=== Delete Product ===");
        var products = _productService.showAllProducts();
        foreach (var product in products)
        {
            Console.WriteLine($" ProductId : {product.ProductID} Product name : {product.ProductName}");
        }
        Console.Write("Enter the ID of the product you want to delete: ");
        int productId = int.Parse(Console.ReadLine());

        _productService.DeleteProduct(productId);

        Console.WriteLine("Product deleted successfully!");
        Console.ReadKey();
    }

    public string GetInfo()
    {
        return "Delete product";
    }
}