using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.secureReply
{
    class GetReplyOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The specified reply */
        public ReplyVOWS replyVO { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append("replyVO: ");
            thisString.Append((this.replyVO == null) ? "<null>" : this.replyVO.toString());
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
