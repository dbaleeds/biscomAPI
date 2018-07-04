using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.delivery
{
    class ExtDeliveryVOWS : DeliveryVOWS
    {
        // Instance variables
        /** The name of the package */
        public string packageName { get; set; }
        /** The email address of the sender */
        public string senderEmailAddress { get; set; }
        /** The first name of the sender */
        public string senderFirstName { get; set; }
        /** The last name of the sender */
        public string senderLastName { get; set; }
        /** The status of the sender */
        public string senderStatus { get; set; }
        /* parsed date with timezone */
        public string parsedDateAvailable { get; set; }
        public string parsedDateExpires { get; set; }
        public string parsedDateCreated { get; set; }
        public string parsedDateLastUpdated { get; set; }
        public string parsedLastActivityDate { get; set; }
        /* Delivery is received as To, Cc or Bcc */
        public string receivedAs { get; set; }
        public string sentToGroupName { get; set; }

        /** Get the Recipient object*/
        public RecipientsWS recipients { get; set; }
        public List<DocumentVOWS> documentVOList { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append(toString1());
            thisString.Append("packageName: ");
            thisString.Append((this.name == null) ? "<null>" : this.name);
            thisString.Append(NEW_LINE);
            thisString.Append("senderEmailAddress: ");
            thisString.Append((this.senderEmailAddress == null) ? "<null>" : this.senderEmailAddress);
            thisString.Append(NEW_LINE);
            thisString.Append("senderFirstName: ");
            thisString.Append((this.senderFirstName == null) ? "<null>" : this.senderFirstName);
            thisString.Append(NEW_LINE);
            thisString.Append("senderLastName: ");
            thisString.Append((this.senderLastName == null) ? "<null>" : this.senderLastName);
            thisString.Append(NEW_LINE);
            thisString.Append("senderStatus: ");
            thisString.Append((this.senderStatus == null) ? "<null>" : this.senderStatus);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
