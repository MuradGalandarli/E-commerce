/*using EntityCommerce;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccess.Commerce
{
    public class ApplicationContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base (options)    
        {
            
        }
        public DbSet<Category>Categorys { get; set; }
        public DbSet<Order>Orders { get; set; }
        public DbSet<Goods>Goodses { get; set; }
        public DbSet<Seller>Sellers { get; set; }
        public DbSet<User>Users { get; set; }


    }
}
*/




using EntityCommerce;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Commerce
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        // Diğer DbSet tanımlamaları
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Goods> Goodses { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<User> Users { get; set; }
        
        public DbSet<Payment>Patments { get; set; }



    }
}
