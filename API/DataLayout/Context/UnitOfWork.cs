using DataLayout.Core.IConfiguration;
using DataLayout.Model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayout.Context
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext context;
        private ILogger logger;

        public UnitOfWork(AppDbContext _context, ILoggerFactory _logger)
        {
            context = _context;
            logger = _logger.CreateLogger("ApplicationLogs");
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
