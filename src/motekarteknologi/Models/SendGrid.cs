using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace motekarteknologi.Models
{
    public class SendGrid
    {
        public SendGrid()
        {
            //will only contain one row SendGrid secret data
            this.ID = Statics.SendGridKey.Value;
            this.SendGridUser = "";
            this.SendGridKey = "";
        }
        public string ID { get; set; }
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
