using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BillPaymentViewer.Core.Entities
{

    [Table("LTE_CUSTOMER")]
    public class LTECustomers
    {
        //public LTECustomers()
        //{
        //    Payment = new HashSet<Payments>();
           
        //}
        
        [Key]
        public decimal CUSTID { get; set; }
        public string NAME { get; set; }
        public string TEL { get; set; }
        public string CUSTACCNUM { get; set; }

        
    }
}
