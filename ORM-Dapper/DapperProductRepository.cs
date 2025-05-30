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
}
