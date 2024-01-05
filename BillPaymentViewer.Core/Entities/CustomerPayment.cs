using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.Entities
{
   public class CustomerPayment
    {

        public string NAME { get; set; }
        public List<Payments> payments { get; set; }
        
    }
}
