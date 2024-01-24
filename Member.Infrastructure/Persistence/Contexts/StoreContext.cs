using System;
using System.Runtime.CompilerServices;
using Member.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Member.Infrastructure.Persistence.Contexts
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}

