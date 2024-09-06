// See https://aka.ms/new-console-template for more information
using AspNetWeb_NLayer.BLL.BussinesModels;
using AspNetWeb_NLayer.BLL.Infrastructure;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Entities;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("BLL is lunched");

string dbConnection = "data source=DESKTOP-9C2MS1P\\SQLEXPRESS; Database=products; Trusted_Connection=TRUE; MultipleActiveResultSets=TRUE; TrustServerCertificate=True;";
var optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
var options = optionsBuilder.UseSqlServer(dbConnection).Options;

var productContext = new ProductContext(options);
var products = productContext.productItems;

foreach (var product in products)
{
    Console.WriteLine(product.name);
}

var ps = new ProductService(new UnitOfWork(productContext));
try
{
    Console.WriteLine(ps.getProductDto("c++").typeEngeeniring);
}
catch (ProductItemException pex)
{
    Console.WriteLine($"{pex.Message} - {pex.property}");
}