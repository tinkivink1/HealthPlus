using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthPlus.Models;

namespace HealthPlus.Data
{
    public class HealthPlusUsersContext : DbContext
    {
       
        public HealthPlusUsersContext (DbContextOptions<HealthPlusUsersContext> options)
            : base(options)
        {
           
        }

        public DbSet<HealthPlus.Models.Users>? Users { get; set; } = null!;
        public DbSet<HealthPlus.Models.Trainings>? Trainings { get; set; } = null!;
    }
}
