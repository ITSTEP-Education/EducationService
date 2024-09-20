using AspNetWeb_NLayer.BLL.Interfaces;
using AspNetWeb_NLayer.BLL.Services;
using AspNetWeb_NLayer.DAL.Interfaces;
using AspNetWeb_NLayer.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetWeb_NLayer.BLL.Tests.Fixtures
{
    public class DependencyInjectionFixture
    {
        public IServiceProvider serviceProvider { get; private set; }

        public DependencyInjectionFixture()
        {
            var services = new ServiceCollection();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductService, ProductService>();

            serviceProvider = services.BuildServiceProvider();
        }
    }
}
