using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BillPaymentViewer.Core.Entities
{
    [Table("PAYBILLVIEW_USERS")]
    public class Systemuser
    {
        [Key]
        public decimal USERID { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }

        public string USERLEVEL { get; set; }
        
    }
}
