using Microsoft.EntityFrameworkCore;

namespace HealthPlus.Models
{

    public class ApplicationContext : DbContext
    {
        public DbSet<Client> clients { get; set; }
#pragma warning disable CS8618 // свойство "clients", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
#pragma warning restore CS8618 // свойство "clients", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
            : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
    }

}
