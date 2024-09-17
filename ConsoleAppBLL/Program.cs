// See https://aka.ms/new-console-template for more information
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Repositories;
using AspNetWeb_NLayer.BLL.BussinesModels;
using System.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("BLL is lunched");

        var productContext = new ProductContext();
        var products = productContext.productItems;

        try
        {
            var ps = new ProductService(new UnitOfWork(productContext));

            //var items = ps.db.productItems.getAllItems();
            //var item0 = items.ElementAt(0);
            //Console.WriteLine(item0.description);

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