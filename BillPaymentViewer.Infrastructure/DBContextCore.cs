using BillPaymentViewer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Infrastructure
{
   public class DBContextCore : DbContext
    {
        public DBContextCore(DbContextOptions<DBContextCore> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SLTCRM");
        }

        public DbSet<Payments> PAYMENTs { get; set; }
        public DbSet<LTECustomers> LTE_CUSTOMERs { get; set; }
        public DbSet<Systemuser> SYSTEMUSERs { get; set; }
    }
}
