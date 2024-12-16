namespace MyStoreNamespace;

public interface IProductService
{
    void AddProduct(Product product);
    List<Product> showAllProducts();
    Product ReadById(int id);
    void UpdateProduct(int ProductId,string newName,decimal newPrice);
    void ChangeQuantity(int ProductId, int Quantity);
    void DeleteProduct(int id);
}