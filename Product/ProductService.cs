namespace MyStoreNamespace;

public class ProductService:IProductService
{ 
    public ProductRepository Repository{ get; set; } 

    public ProductService(ProductRepository repository)
    {
        this.Repository = repository;
    }
    
    public void AddProduct(Product product)
    {
        Repository.Create(product);
    }

    public List<Product> showAllProducts()
    {
        return Repository.ReadAll();
    }

    public Product ReadById(int id)
    {
        return Repository.ReadById(id);
    }
    public void UpdateProduct(int ProductId, string newName, decimal newPrice)
    {
        Repository.Update(ProductId, newName, newPrice);
    }

    public void ChangeQuantity(int ProductId, int Quantity)
    {
        Repository.ChangeQuantity(ProductId, Quantity);
    }

    public void DeleteProduct(int id)
    {
        Repository.Delete(id);
    }
}