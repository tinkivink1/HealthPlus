using Microsoft.EntityFrameworkCore;


namespace HealthPlus.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<user> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }
}



