using Microsoft.EntityFrameworkCore;
using OBT_TestTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBT_TestTask.Services
{
    public class AppDBContext : DbContext
    {
        public virtual DbSet<BudgetAccount> Accounts { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<ChangeDebt> ChangesDebt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Budget;Username=postgres;Password=123");
        }
    }
}
