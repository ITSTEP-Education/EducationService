// See https://aka.ms/new-console-template for more information
using AspNetWeb_NLayer.BLL.DTO;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using AspNetWeb_NLayer.BLL.BussinesModels;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("BLL is lunched");

        string DefaultDbConnection = "data source=DESKTOP-9C2MS1P\\SQLEXPRESS; Database=products; Trusted_Connection=TRUE; MultipleActiveResultSets=TRUE; TrustServerCertificate=True;";
        var options = new DbContextOptionsBuilder<ProductContext>().UseSqlServer(DefaultDbConnection).Options;

        var productContext = new ProductContext(options);
        var products = productContext.productItems;

        try
        {
            var ps = new ProductService(new UnitOfWork(productContext));
            var item = ps.db.productItems.getItem("c++");
            Console.WriteLine($"ProductItem: {item?.name} | {item?.typeEngeeniring} | {item?.durationMonth} | {item?.price}");

            var pio = ps.getProductOrder("c++", 
                new ClientTimeProperty() { EducationForm = "holiday" }, 
                new ClientPayProperty() { IsInvitedPerson = false, PayMethod = "cash", PayPeriod = "monthly"});

            Console.WriteLine($"ProductOrder: {pio.name} | {pio.typeEngeeniring} | {pio.timeStudy} | {pio.sumPay}");
        }
        catch (ProductItemException pex)
        {
            Console.WriteLine($"{pex.Message} - {pex.property}");
        }
    }
}

//var services = new ServiceCollection();
//services.AddDbContext<ProductContext>(options => options.UseSqlServer(DefaultDbConnection));
//var serviceProvider = services.BuildServiceProvider();