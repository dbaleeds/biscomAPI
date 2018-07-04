using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.secureReply
{
    class ReplyVOWS
    {
        // Instance variables
        /** The reply's id. */
        public int replyId { get; set; }
        /** The reply's topic id. */
        public int topicId { get; set; }
        /** The reply's status. */
        public string status { get; set; }
        /** The reply's sequence number within topic. */
        public int replyNum { get; set; }
        /** The reply who created the record. */
        public int createdBy { get; set; }
        /** The date when the record was created. */
        public DateTime dateCreated { get; set; }
        /** The reply who last updated the record. */
        public int lastUpdatedBy { get; set; }
        /** The date when the record was last updated. */
        public DateTime dateLastUpdated { get; set; }
        /** The reply's subject. */
        public string replySubject { get; set; }
        /** The reply's body. */
        public string replyMessage { get; set; }
        /** The reply's notification message. */
        public string replySystemMessage { get; set; }
        /** The read indicator */
        public Boolean read { get; set; }
        /** The reply's view count. */
        public int totalViewed { get; set; }
        /** Virus scan status*/
        public string scanStatus { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("replyId: ");
            thisString.Append(this.replyId);
            thisString.Append(NEW_LINE);
            thisString.Append("topicId: ");
            thisString.Append(this.topicId);
            thisString.Append(NEW_LINE);
            thisString.Append("status: ");
            thisString.Append((this.status != null) ? this.status : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("replyNum: ");
            thisString.Append(this.replyNum);
            thisString.Append(NEW_LINE);
            thisString.Append("createdBy: ");
            thisString.Append(this.createdBy);
            thisString.Append(NEW_LINE);
            thisString.Append("dateCreated: ");
            thisString.Append((this.dateCreated == null) ? "<null>" : this.dateCreated.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("lastUpdatedBy: ");
            thisString.Append(this.lastUpdatedBy);
            thisString.Append(NEW_LINE);
            thisString.Append("dateLastUpdated: ");
            thisString.Append((this.dateLastUpdated == null) ? "<null>" : this.dateLastUpdated.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("replySubject: ");
            thisString.Append((this.replySubject != null) ? this.replySubject : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("replyMessage: ");
            thisString.Append((this.replyMessage != null) ? this.replyMessage : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("replySystemMessage: ");
            thisString.Append((this.replySystemMessage != null) ? this.replySystemMessage : "<null>");
            thisString.Append(NEW_LINE);
            thisString.Append("read: ");
            thisString.Append(this.read);
            thisString.Append(NEW_LINE);
            thisString.Append("totalViewed: ");
            thisString.Append(this.totalViewed);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
