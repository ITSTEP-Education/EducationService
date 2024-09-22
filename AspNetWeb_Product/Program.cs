using Asp.Versioning;
using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.EF;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.DAL.Repositories;
using AspNetWeb_Product.Swagger;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductContext>(config => config.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDbConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductService, ProductService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//set for varsioning in Swagger;
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddSwaggerGen(options =>
{
    //add custom operation filter which sets default values
    options.OperationFilter<SwaggerDefaultValues>();

    //connect service of display XML comments in SwaggerUI
    var basePath = AppContext.BaseDirectory;
    options.IncludeXmlComments(Path.Combine(basePath, "ProductItemApi.xml"));
    options.IncludeXmlComments(Path.Combine(basePath, "BLL.xml"));
});

//Add services of versioning in Swagger
builder.Services.AddApiVersioning(configure =>
{
    configure.DefaultApiVersion = new ApiVersion(1, 0);
    configure.AssumeDefaultVersionWhenUnspecified = true;
    configure.ReportApiVersions = true;
    configure.ApiVersionReader = new UrlSegmentApiVersionReader();
});

builder.Services.AddApiVersioning().AddApiExplorer(configure =>
{
    configure.GroupNameFormat = "'v'VVV";
    configure.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(configure => { 
        configure.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");

        var descriptions = app.DescribeApiVersions();

        //Build a swagger endpoint for each dicovered API version
        foreach (var desctiption in descriptions)
        {
            var url = $"/swagger/{desctiption.GroupName}/swagger.json";
            var name = desctiption.GroupName.ToUpperInvariant();
            configure.SwaggerEndpoint(url, name);
        }
    });

    app.UseMvc(routes =>
    {
        routes.MapRoute(
            name: "default",
            template: "/{controller=ProductItem}/{action=Get}/{all-productitems-dto}"
            );
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
