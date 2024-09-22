using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductContext>(config => config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1.0.0", new OpenApiInfo
    {
        Version = "v1.0.0",
        Title = "ProductItem Api",
        Description = "Api request to get ProductItem and convert it to ProductOrder",
        Contact = new OpenApiContact
        {
            Name = "KostiantynPolishko",
            Email = "polxs_wp31@student.itstep.org",
            Url = new Uri("https://github.com/KostiantynPolishko2/AspNetWeb_NLayer/tree/dev_MultyLayers")
        },
        License = new OpenApiLicense
        {
            Name = "ApiITSTEP",
            Url = new Uri("https://mystat.itstep.org/")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/v1.0.0/swagger.json", "v1.0.0");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
