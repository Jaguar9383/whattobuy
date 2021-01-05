using Microsoft.EntityFrameworkCore;

namespace WhatToBuy.Context
{
    public class WhatToBuyContext : DbContext
    {
        public DbSet<ToBuyList> Lists {get;set;}
        public DbSet<Product> Products {get;set;}

        public WhatToBuyContext(DbContextOptions<WhatToBuyContext> options): base(options)
        {
            
        }
    }

}