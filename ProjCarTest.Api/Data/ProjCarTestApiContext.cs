using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjCarTest.Api.Models;

namespace ProjCarTest.Api.Data
{
    public class ProjCarTestApiContext : DbContext
    {
        public ProjCarTestApiContext (DbContextOptions<ProjCarTestApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProjCarTest.Api.Models.Car> Car { get; set; }
    }
}
