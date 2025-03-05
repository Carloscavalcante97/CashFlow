using CashFlow.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.Migrations
{
    public static class DataBaseMigration
    {
        public async static Task MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<CashFlowDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
