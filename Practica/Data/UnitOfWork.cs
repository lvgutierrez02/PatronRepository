using Microsoft.Extensions.Logging;
using Practica.Core.Repositories;
using Practica.IConfiguration;
using System;
using System.Threading.Tasks;

namespace Practica.Data
{
    // 1:01:00 explicación vídeo  
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            AppDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");


            Users = new UserRepository(context, _logger);
        }


        public async Task CompleteAsync()
        {

            await _context.SaveChangesAsync();

        }

        public void Dispose()
        {

            _context.Dispose();

        }
    }
}
        
