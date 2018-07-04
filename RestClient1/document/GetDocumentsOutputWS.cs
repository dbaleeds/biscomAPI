using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1.document
{
    class GetDocumentsOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of document value objects */
        public List<DocumentVOWS> documentVOs { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append("documentVOs: ");
            foreach (DocumentVOWS documentVO in documentVOs)
            {
                thisString.Append((documentVO != null) ? documentVO.toString() : "<null>");
                thisString.Append(NEW_LINE);
            }

            thisString.Append("totalRowCount: ");
            thisString.Append(this.totalRowCount);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
