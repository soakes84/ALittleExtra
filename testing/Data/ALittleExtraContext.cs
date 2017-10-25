using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace testing.Data
{
    public class ALittleExtraContext : IdentityDbContext<ApplicationUser>
	{
		public DbSet<TotalFood> TotalFood { get; set; }
		public DbSet<BoxFood> BoxFood { get; set; }
		public DbSet<CanFood> CanFood { get; set; }
		public DbSet<Fruit> Fruit { get; set; }
		public DbSet<Meat> Meat { get; set; }
		public DbSet<Vegetables> Vegetables { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Dairy> Dairy { get; set; }
	
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Data Source=ALittleExtra.db");
			//optionsBuilder.UseSqlite(@"Data Source=:memory:;New=True");
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder builder)
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
