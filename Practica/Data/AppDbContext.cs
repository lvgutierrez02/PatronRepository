using Microsoft.EntityFrameworkCore;
using Practica.Models;

namespace Practica.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }  

    }
}
