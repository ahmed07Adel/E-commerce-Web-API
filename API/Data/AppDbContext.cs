using API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<UserGender> UserGenders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ProductsModel> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductinCart> Productincarts { get; set; }
        public DbSet<ProductRating> productRatings { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserGender>().HasData(new UserGender
            {
               Id = 1,
               Name = "Male"
            });
            builder.Entity<UserGender>().HasData(new UserGender
            {
                Id = 2,
                Name = "Female"
            });
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Clothes" }
                );
            builder.Entity<Category>().HasData(
               new Category { Id = 2, Name = "Electronics" }
               );
            base.OnModelCreating(builder);

        }
    }
}
