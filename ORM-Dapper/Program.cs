using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            //create instance of DapperDepartmentsRepository
            var departmentRepo = new DapperDepartmentRepository(conn);
            
            //call InsertDepartment method to insert a new department into departments table (uncomment to execute)
            //departmentRepo.InsertDepartment("New Department");
            
            //call GetAllDepartments method to store all rows from departments table into a list
            var departments = departmentRepo.GetAllDepartments();
            
            Console.WriteLine("Department list:");
            Console.WriteLine("----------------");
            Console.WriteLine();
            
            //loop through list of departments and display each one to the console
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} - {department.Name}");
            }
            
            //create instance of DapperProductsRepository
            var productRepo = new DapperProductRepository(conn);
            
            //call InsertProduct method to insert a new product into products table (uncomment to execute)
            //productRepo.InsertProduct("Orange Juice", 3.00, 10);
            
            //call GetAllProducts method to store all rows from products table into a list
            var products = productRepo.GetAllProducts();
            
            Console.WriteLine("Product list:");
            Console.WriteLine("----------------");
            
            //loop through list of products and display each one to the console
            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} - {product.Name}");
            }
            
            Console.WriteLine();

            //call the GetProductsByID method to store the product we wish to update and set the update values
            var productID = 940;
            var changeProduct = productRepo.GetProductByID(productID);
            changeProduct.OnSale = true;
            changeProduct.StockLevel = 500;
            
            //call the UpdateProduct method to update our product info in the database (uncomment to Update product)
            /*productRepo.UpdateProduct(changeProduct);
            
            Console.WriteLine("Product updated.  The new values are as follows:");
            Console.WriteLine("---------------");
            Console.WriteLine($"Product ID: {changeProduct.ProductID}");
            Console.WriteLine($"Name: {changeProduct.Name}");
            Console.WriteLine($"Price : {changeProduct.Price}");
            Console.WriteLine($"CategoryID: {changeProduct.CategoryID}");
            Console.WriteLine($"On Sale: {changeProduct.OnSale}");
            Console.WriteLine($"Stock Level: {changeProduct.StockLevel}");
            */
            
            //call the DeleteProduct method to delete a product (uncomment to delete product)
            /*productRepo.DeleteProduct(productID);
            
            Console.WriteLine($"Product deleted.");*/
        }
    }
}
