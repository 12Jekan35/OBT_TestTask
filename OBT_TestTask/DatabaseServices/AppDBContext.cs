using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;
using OBT_TestTask.Models;

namespace OBT_TestTask.DatabaseServices
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(): base(nameOrConnectionString:"OBTConnection")
        {

        }

        public virtual DbSet<BudgetAccount> Accounts { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }
        public virtual DbSet<ChangeDebt> ChangesDebt { get; set; }
    }
}
