using System;
               
namespace ALittleExtra.Data
{
    public class ALittleMoreContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<TotalFood> TotalFood { get; set; }
        public DbSet<BoxFood> BoxFood { get; set; }
        public DbSet<CanFood> CanFood { get; set; }
        public DbSet<Fruit> Fruit { get; set; }
        public DbSet<Meat> Meat { get; set; }
        public DbSet<Vegetables> Vegetables { get; set; }
        public DbSet<HighPriority> HighPriority { get; set; }
        public DbSet<LowPriority> LowPriority { get; set; }

        public ALittleMoreContext()
        {
        }
    }
}
