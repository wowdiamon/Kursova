namespace MyStoreNamespace;

public interface IProductRepository
{
    
    void Create(Product product);
    List<Product> ReadAll();
    void Update(int ProductId,string newName,decimal newPrice);
    void ChangeQuantity(int ProductId,int newQuantity);
    void Delete(int id);
    
}