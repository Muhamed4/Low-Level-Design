using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chess_C_.Data;
using Microsoft.EntityFrameworkCore;

namespace ChessC_UnitTest.Data
{
    public class InMemoryDbContext: AppDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
        }

        public override void Dispose()
        {
            Database.EnsureDeleted();
            base.Dispose();
        }

    }
}