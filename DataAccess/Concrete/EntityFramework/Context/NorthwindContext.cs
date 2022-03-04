using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Context
{
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Northwind;Trusted_Connection=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<UserProfilePhoto> ProfilePhotos { get; set; }
        public DbSet<Fallow> Fallows { get; set; }
        public DbSet<Message> Messages { get; set; }





    }
}
