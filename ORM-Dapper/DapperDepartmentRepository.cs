using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _conn;

    public DapperDepartmentRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _conn.Query<Department>("SELECT * FROM departments");
    }

    public void InsertDepartment(string name)
    {
        _conn.Execute("INSERT INTO departments (Name) VALUES (@name)", new {name = name});
    }
}