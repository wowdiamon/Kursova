namespace MyStoreNamespace;

public class Product
{
    private static int _nextId = 1;
    private static readonly Stack<int> ReusableIds = new Stack<int>();
    public string ProductName { get; set; }

    private int _quantity;

    public int Quantity
    {
        get => _quantity; 
        internal set
        {
            if (value < 0)
            {
                throw new ArgumentException("Quantity cannot be less than 0.");
            }
            _quantity = value;
        }
    }

    public decimal Price { get; set; }
    public int ProductID { get; set; }
    

    public Product(string productName,decimal price)
    {
        ProductName = productName;
        Price= price;
        ProductID = ReusableIds.Count > 0 ? ReusableIds.Pop() : _nextId++;
    }
    
}