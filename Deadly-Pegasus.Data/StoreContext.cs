﻿using Deadly.Pegasus.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Deadly.Pegasus.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        
    }
}
