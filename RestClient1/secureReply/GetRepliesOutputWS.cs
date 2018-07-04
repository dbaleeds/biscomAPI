using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.secureReply
{
    class GetRepliesOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of reply value objects */
        public List<ReplyVOWS> replies { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append("replyVOs: ");
            foreach (ReplyVOWS replyVOWS in replies)
            {
                thisString.Append((replyVOWS != null) ? replyVOWS.toString() : "<null>");
                thisString.Append(NEW_LINE);
            }
            thisString.Append(NEW_LINE);
            thisString.Append("totalRowCount: ");
            thisString.Append(this.totalRowCount);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
