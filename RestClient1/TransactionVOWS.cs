using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class TransactionVOWS
    {
        // Instance variables

        /** The transaction id. */
        public int transactionId { get; set; }
        /** The transaction date. */
        public DateTime transactionDate { get; set; }
        /** The parsed transaction date. */
        public string parsedTransactionDate{ get; set; }
        /** The status. */
        public string status{ get; set; }
        /** The transaction level. */
        public int level{ get; set; }
        /** The type. */
        public string type { get; set; }
        /** The category. */
        public string category { get; set; }
        /** The target. */
        public string target { get; set; }
        /** The action. */
        public string action { get; set; }
        /** User id. */
        public int userId { get; set; }
        /** The parent transaction id. */
        public int parentTransactionId { get; set; }
        /** Package id. */
        public int packageId { get; set; }
        /** Package version. */
        public int version { get; set; }
        /** Delivery id. */
        public int deliveryId { get; set; }
        /** Document id. */
        public int documentId { get; set; }
        /** Document name. */
        public string documentName { get; set; }
        /** Target user id. */
        public int targetUserId { get; set; }
        /** The log entry. */
        public string logEntry { get; set; }
        /** The old value. */
        public string oldValue { get; set; }
        /** The new value. */
        public string newValue { get; set; }
        /** The IP address */
        public string ipAddress { get; set; }
        /** The Channel Type */
        public string channelType { get; set; }


        /**
     * Returns the string representation of the object.
     * @return The string representation of the object.
     */
        public string toString() {
        string NEW_LINE = "\n";
 
        StringBuilder thisstring = new StringBuilder();
        thisstring.Append("transactionId: ");
        thisstring.Append(this.transactionId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("transactionDate: ");
        thisstring.Append((this.transactionDate == null) ? "<null>" : this.transactionDate.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("status: ");
        thisstring.Append((this.status == null) ? "<null>" : this.status.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("level: ");
        thisstring.Append(this.level);
        thisstring.Append(NEW_LINE);
        thisstring.Append("type: ");
        thisstring.Append((this.type == null) ? "<null>" : this.type.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("category: ");
        thisstring.Append((this.category == null) ? "<null>" : this.category.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("target: ");
        thisstring.Append((this.target == null) ? "<null>" : this.target.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("action: ");
        thisstring.Append((this.action == null) ? "<null>" : this.action.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("userId: ");
        thisstring.Append(this.userId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("parentTransactionId: ");
        thisstring.Append(this.parentTransactionId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("packageId: ");
        thisstring.Append(this.packageId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("version: ");
        thisstring.Append(this.version);
        thisstring.Append(NEW_LINE);
        thisstring.Append("deliveryId: ");
        thisstring.Append(this.deliveryId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("documentId: ");
        thisstring.Append(this.documentId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("documentName: ");
        thisstring.Append((this.documentName == null) ? "<null>" : this.documentName.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("targetUserId: ");
        thisstring.Append(this.targetUserId);
        thisstring.Append(NEW_LINE);
        thisstring.Append("logEntry: ");
        thisstring.Append((this.logEntry == null) ? "<null>" : this.logEntry.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("oldValue: ");
        thisstring.Append((this.oldValue == null) ? "<null>" : this.oldValue.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append("newValue: ");
        thisstring.Append((this.newValue == null) ? "<null>" : this.newValue.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append((this.ipAddress == null) ? "<null>" : this.ipAddress.ToString());
        thisstring.Append(NEW_LINE);
        thisstring.Append((this.channelType == null) ? "<null>" : this.channelType.ToString());
        thisstring.Append(NEW_LINE);

        return thisstring.ToString();
    }
    }
}
