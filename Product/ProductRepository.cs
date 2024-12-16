namespace MyStoreNamespace;

public class ProductRepository: IProductRepository
{
    public DbContext Context { get; set; }
         
    public ProductRepository(DbContext Context)
    {
        this.Context = Context;
    }

    public void Create(Product product)
    {
        Context.Products.Add(product);
    }

    public List<Product> ReadAll()
    {
        return Context.Products.Count == 0 ? null : Context.Products;
    }

    public Product ReadById(int id)
    {
        return Context.Products.FirstOrDefault(p => p.ProductID == id);
    }
    
    public void Update(int ProductId, string newName, decimal newPrice)
    {
        var existingProductIndex = Context.Accounts.FindIndex(p => p.Id == ProductId);
                 
        var existingProduct = Context.Products[existingProductIndex];
        Account.ReleaseId(existingProduct.ProductID);
        int id = existingProduct.ProductID;
        int Quantity = existingProduct.Quantity;
        Delete(ProductId);

        Product updatedProduct = new Product(newName,newPrice);

        updatedProduct.ProductID = id;

        Create(updatedProduct);
    }

    public void ChangeQuantity(int ProductId,int newQuantity)
    {
        var existingProduct = ReadById(ProductId);
        
        existingProduct.Quantity = newQuantity;
    }

    public void Delete(int id)
    {
        var product = ReadById(id);
        if (product != null)
        {
            Context.Products.Remove(product);
        }
    }
}