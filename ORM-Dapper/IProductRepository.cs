namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void InsertProduct(string name, double price, int categoryID);
    public void UpdateProduct(string name, double price, int categoryID);
}
