using System;
using System.Collections.Generic;
using System.Text;

namespace BillPaymentViewer.Core.Entities
{
   public class User
    {
        public string username { get; set; }
        public string password { get; set; }

        public string token { get; set; }

        public string userlevel { get; set; }
    }
}
