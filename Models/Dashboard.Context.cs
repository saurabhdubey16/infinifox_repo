using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace VMP.Dashboard.Models
{
    public partial class DashboardContext : DbContext
    {
        public DashboardContext()
        {
        }

        public DashboardContext(DbContextOptions<DashboardContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString = Startup.MyConn;
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
