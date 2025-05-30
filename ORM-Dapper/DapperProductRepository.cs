using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    public DapperProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products");
    }

    public void InsertProduct(string name, double price, int categoryID)
    {
        _conn.Execute("INSERT INTO products (Name, price, categoryID) VALUES (@name, @price, @categoryID)", new { name, price, categoryID });
    }

    public Product GetProductByID(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @id", new { id });
    }

    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE products " + 
                          "SET Name = @name, Price = @price, CategoryID = @cID, OnSale = @onSale, StockLevel = @sLevel " +
                          "WHERE ProductID = @id;", 
                     new { name = product.Name, 
                                 price = product.Price, 
                                 cID = product.CategoryID, 
                                 onSale = product.OnSale, 
                                 sLevel = product.StockLevel,
                                 id = product.ProductID });
    }

    public void DeleteProduct(int id)
    {
        _conn.Execute("DELETE FROM products " +
                          "WHERE ProductID = @id;", 
                     new { id });
    }
}
