using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCaseStudyCFTry1.Models;

namespace WebApiCaseStudyCFTry1.Data
{
    public class CaseStudyDbContext : DbContext
    {
        public CaseStudyDbContext (DbContextOptions<CaseStudyDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApiCaseStudyCFTry1.Models.Administrators> Administrators { get; set; } = default!;

        public DbSet<WebApiCaseStudyCFTry1.Models.Users>? Users { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Sellers>? Sellers { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Categories>? Categories { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Products>? Products { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Cart>? Cart { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Orders>? Orders { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Order_items>? Order_items { get; set; }

        public DbSet<WebApiCaseStudyCFTry1.Models.Payments>? Payments { get; set; }
    }
}
