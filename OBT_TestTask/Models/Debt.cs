using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBT_TestTask.Models
{
    [Table("Debts", Schema = "public")]
    public class Debt
    {
        [Key]
        [Column("ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        [Column("AllSum")]

        public decimal AllSum { get; set; }
        [Column("LongTerm")]

        public decimal LongTerm { get; set; }
        [Column("Overdue")]

        public decimal Overdue { get; set; }

        public override string ToString()
        {
            return AllSum.ToString();
        }
    }
}
