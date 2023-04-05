using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectWebApiDotnet.Models.Entites;

    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<ProjectWebApiDotnet.Models.Entites.Department> Department { get; set; } = default!;

        public DbSet<ProjectWebApiDotnet.Models.Entites.Seller> Seller { get; set; } = default!;

        public DbSet<ProjectWebApiDotnet.Models.Entites.SalesRecord> SalesRecords { get; set; } = default!;
}
