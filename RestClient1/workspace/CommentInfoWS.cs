using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class CommentInfoWS
    {
        /** The date when the record was created. */
        public DateTime dateCreated { get; set; }

        public string parsedDateCreated { get; set; }

        /** comment created by */
        public string createdBy { get; set; }

        /** comment detail */
        public string replyMessage { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("createdBy: ");
            thisString.Append(this.createdBy);
            thisString.Append(NEW_LINE);
            thisString.Append("dateCreated: ");
            thisString.Append((this.dateCreated == null) ? "<null>" : this.dateCreated.ToString());
            thisString.Append(NEW_LINE);
            thisString.Append("replyMessage: ");
            thisString.Append((this.replyMessage != null) ? this.replyMessage : "<null>");
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
