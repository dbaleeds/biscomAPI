using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class RecipientsWS
    {
        // Instance variables

        //---------------------------------------This section works for multiple recipients only---------------------------------------------
        
        /*
        // List of TO recipients
        private List<String> toAddressListEntries = new List<String>();

        public List<String> ToAddressListEntries
        {
            get { return toAddressListEntries; }
            set { toAddressListEntries = value; }
        }
        public int totalToRecipients { get; set; }
        // List of CC recipients
        private List<String> ccAddressListEntries = new List<String>();

        public List<String> CcAddressListEntries
        {
            get { return ccAddressListEntries; }
            set { ccAddressListEntries = value; }
        }
        public int totalCcRecipients { get; set; }
        // List of BCC recipients
       private List<String> bccAddressListEntries = new List<String>();

        public List<String> BccAddressListEntries
        {
            get { return bccAddressListEntries; }
            set { bccAddressListEntries = value; }
        }
        public int totalBccRecipients { get; set; }
        */

        //---------------------------------------This section works for single recipient only---------------------------------------------
        
        public string toAddressListEntries { get; set; }
        public string totalBccRecipients { get; set; }
        public string totalCcRecipients { get; set; }
        public string totalToRecipients { get; set; } 
    } 
}
