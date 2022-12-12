using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Data.Context;

namespace Pottencial.Test.Data
{
    public class BaseTest
    {
        public BaseTest()
        {
            
        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest {Guid.NewGuid().ToString().Replace("-",string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }
        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<PottencialContext>(o =>
            o.UseSqlServer($"Server=localhost;Database={dataBaseName};User Id=sa;Password=12345;TrustServerCertificate=True;"),
                ServiceLifetime.Transient);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            using (var context = ServiceProvider.GetService<PottencialContext>())
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<PottencialContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
        
    }
}