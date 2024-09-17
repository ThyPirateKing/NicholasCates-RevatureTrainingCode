using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NicholasCates.API-Program-Tutorial.Data
{
    public class ApplicationDBContext : DBContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Comment> Comments { get; set; }


    }
}