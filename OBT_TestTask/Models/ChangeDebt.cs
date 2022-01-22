using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBT_TestTask.Models
{
    [Table("ChangesDebt", Schema = "public")]
    public class ChangeDebt
    {
        [Key]
        [Column("ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; private set; }
        [Column("AllSum")]
        public decimal AllSum { get; set; }
        [Column("NonMonetaryPart")]
        public decimal NonmonetaryPart { get; set; }

    }
}
