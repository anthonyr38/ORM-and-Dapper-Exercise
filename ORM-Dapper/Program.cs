using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

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

            /*
            var departmentRepo = new DapperDepartmentRepository(conn);

            var departments = departmentRepo.GetAllDepartments();

            foreach (var department in departments) 
            {
                Console.WriteLine(department.DepartmentID);
                Console.WriteLine(department.Name);
                Console.WriteLine();
                Console.WriteLine();
            }
            */


            
            var repo = new DapperProductRepository(conn);

            //Console.WriteLine("What is the name of your new product?");
            //var prodName = Console.ReadLine();

            //Console.WriteLine("What is the price of your new product?");
            //var prodPrice = double.Parse(Console.ReadLine());

            //Console.WriteLine("What is the category ID?");
            //var prodCat = int.Parse(Console.ReadLine());

            //repo.CreateProduct(prodName, prodPrice, prodCat);

            var prodList = repo.GetAllProducts();

            var productUpdate = repo.GetProduct(900);

            productUpdate.Name = "Been Updated";
            productUpdate.Price = 16.99;
            productUpdate.CategoryID = 1;
            productUpdate.OnSale = false;
            productUpdate.StockLevel = 500;


            repo.UpdateProduct(productUpdate);


            repo.DeleteProduct(900);



            foreach (var prod in prodList) 
            {
                Console.WriteLine($"{prod.ProductID} - {prod.Name}");
                Console.WriteLine();
            }
            



        }
    }
}
