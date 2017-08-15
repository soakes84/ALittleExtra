using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public ALittleMoreContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=ALittleExtra.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder )
        {
			base.OnModelCreating(builder);

			builder.Entity<ApplicationUser>()
				.ToTable("Users");
			builder.Entity<IdentityRole>()
				.ToTable("Roles");
			builder.Entity<IdentityRoleClaim<string>>()
				.ToTable("RoleClaims");
			builder.Entity<IdentityUserClaim<string>>()
				.ToTable("UserClaims");
			builder.Entity<IdentityUserLogin<string>>()
				.ToTable("UserLogins");
			builder.Entity<IdentityUserRole<string>>()
				.ToTable("UserRoles");
			builder.Entity<IdentityUserToken<string>>()
				.ToTable("UserTokens");
            
        }
    }
}
