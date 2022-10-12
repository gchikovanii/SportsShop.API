using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SportsShop.Domain.Entities.ProductAggregate;
using SportsShop.Domain.Entities.UserAggregte;
using SportsShop.Domain.Entities.UserAggregte.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SportsShop.Infrastructure.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, int, IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<Product>().HasKey(i => i.Id);
            builder.Entity<ProductImage>().HasKey(i => i.Id);
            builder.Entity<Address>().HasKey(i => i.Id);


            builder.Entity<AppUser>()
                .HasMany(i => i.AppUserRoles)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
            builder.Entity<AppRole>()
                .HasMany(i => i.AppUserRoles)
                .WithOne(i => i.Role)
                .HasForeignKey(i => i.RoleId);

            builder.Entity<AppUser>()
                .HasOne(i => i.Address)
                .WithOne(i => i.User);
            builder.Entity<Product>()
                .HasMany(i => i.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AppUser>()
                .HasMany(i => i.Orders)
                .WithOne(i => i.Buyer)
                .HasForeignKey(i => i.BuyerId);


        }


    }

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var option = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=DESKTOP-OTPP7O7;Database=SportsShopDB;Trusted_Connection=True;MultipleActiveResultSets=True");
            return new ApplicationDbContext(option.Options);
        }
    }

}
