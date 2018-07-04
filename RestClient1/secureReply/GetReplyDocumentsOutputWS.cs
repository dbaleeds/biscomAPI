using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.secureReply
{
    class GetReplyDocumentsOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of reply document value objects */
        public List<ReplyDocumentVO> replyDocumentVOs { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }


        public String toString()
        {
            String NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append(NEW_LINE);
            thisString.Append("replyDocumentVOs: ");
            thisString.Append(NEW_LINE);
            foreach (ReplyDocumentVO replyDocumentVO in replyDocumentVOs)
            {
                thisString.Append((replyDocumentVO != null) ? replyDocumentVO.toString() : "<null>");
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
