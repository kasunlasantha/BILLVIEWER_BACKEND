using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillPaymentViewer.Core.Entities
{
    [Table("PAYMENT")]
    public class Payments
    {
        [Key]
        public decimal PAYMENTID { get; set; }

        [StringLength(10)]
        public string ACCOUNTNUMBER { get; set; }

        public DateTime? PAYMENTDATE { get; set; }

        public decimal? PAYMENTAMOUNT { get; set; }

        public string BRANCHCODE { get; set; }

       
        public decimal STATUS { get; set; }

        public string ERRORCODE { get; set; }
        

       
    }
}
