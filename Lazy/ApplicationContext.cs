using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lazy
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        //public DbSet<User> Users => Set<User>();
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            bool isAvalaible = Database.CanConnect(); // проверяет подключение к бд
            if (isAvalaible) Console.WriteLine("База данных доступна");
            else Console.WriteLine("База данных не доступна");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        }
    }
}
