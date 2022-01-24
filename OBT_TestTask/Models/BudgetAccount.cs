using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBT_TestTask.Models
{
    [Table("BudgetAccounts", Schema = "public")]
    public class BudgetAccount
    {
        [Key]
        [Column("ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("Code")]
        public string Code { get; set; }
        [Column("FormNumber")]
        public int FormNumber { get; set; }
        [Column("SintAccount")]
        public string SintAccount { get; set; }
        [Column("KOSGU")]
        public string KOSGU { get; set; }
        [Column("StartYearDebtID")]
        public int StartYearDebtID { get; set; }
        [Column("ChangeUpDebtID")]
        public int ChangeUpDebtID { get; set; }
        [Column("ChangeDownDebtID")]
        public int ChangeDownDebtID { get; set; }
        [Column("EndReportPeriodDebtID")]
        public int EndReportPeriodDebtID { get; set; }
        [Column("EndSamePastPeriodID")]
        public int EndSamePastPeriodID { get; set; }

        [ForeignKey("StartYearDebtID")]
        public virtual Debt StartYearDebt { get; set; }
        [ForeignKey("ChangeUpDebtID")]
        public virtual ChangeDebt ChangeUpDebt { get; set; }
        [ForeignKey("ChangeDownDebtID")]
        public virtual ChangeDebt ChangeDownDebt { get; set; }
        [ForeignKey("EndReportPeriodDebtID")]
        public virtual Debt EndReportPeriodDebt { get; set; }
        [ForeignKey("EndSamePastPeriodID")]
        public virtual Debt EndSamePastPeriod { get; set; }
    }
}
