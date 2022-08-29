using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BittiBitti.Persistence.Contexts
{
    public class PostgreDbContext : BaseDbContext
    {
        public PostgreDbContext(DbContextOptions<BaseDbContext> options) :base (options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreDbContext).Assembly);
        }
    }
}
