namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void InsertProduct(string name, double price, int categoryID);
    public Product GetProductByID(int id);
    public void UpdateProduct(Product product);
    public void DeleteProduct(int id);
}
