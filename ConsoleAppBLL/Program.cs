// See https://aka.ms/new-console-template for more information
using AspNetWeb_NLayer.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("BLL is lunched");

        string DefaultDbConnection = "data source=DESKTOP-9C2MS1P\\SQLEXPRESS; Database=products; Trusted_Connection=TRUE; MultipleActiveResultSets=TRUE; TrustServerCertificate=True;";
        //var options = new DbContextOptionsBuilder<ProductContext>().UseSqlServer(DefaultDbConnection).Options;

        var services = new ServiceCollection();
        services.AddDbContext<ProductContext>(options => options.UseSqlServer(DefaultDbConnection));

        var serviceProvider = services.BuildServiceProvider();

        //var productContext = new ProductContext(options);
        //var products = productContext.productItems;

        //foreach (var product in products)
        //{
        //    Console.WriteLine(product.name);
        //}

        //var ps = new ProductService(new UnitOfWork(productContext));
        //try
        //{
        //    Console.WriteLine(ps.getProductDto("c++").typeEngeeniring);
        //}
        //catch (ProductItemException pex)
        //{
        //    Console.WriteLine($"{pex.Message} - {pex.property}");
        //}
    }
}