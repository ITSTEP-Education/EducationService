using AspNetWeb_NLayer.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetWeb_NLayer.DAL.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        public ServiceProvider serviceProvider { get; private set; }
        public ProductContext context { get; private set; }
        private bool disposed = false;
        //private IServiceScope scope;

        public DatabaseFixture()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            var services = new ServiceCollection();
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultDbConnection")));
            serviceProvider = services.BuildServiceProvider();
            context = serviceProvider.GetRequiredService<ProductContext>();
            //scope = serviceProvider.CreateScope();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            //scope.Dispose();
            //serviceProvider.Dispose();
        }
    }
}
