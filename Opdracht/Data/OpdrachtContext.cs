using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opdracht.Models;

namespace Opdracht.Data
{
    public class OpdrachtContext : DbContext
    {
        public OpdrachtContext (DbContextOptions<OpdrachtContext> options)
            : base(options)
        {
        }

        public DbSet<Opdracht.Models.ProductModel> ProductModel { get; set; }
    }
}
