using AutoStocker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoStocker.Domain.DbContexts
{
    public class AutoStockerDbContext
    {
        // DbSet tanımlamaları
        public DbSet<Product> Products { get; set; }
        //public DbSet<Entities.Order> Orders { get; set; }
    }
}
