using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetWorkspaceTransactionsOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of <code>{@link TransactionVO}</code> */
        public List<TransactionVOWS> workspaceTransactionVOs { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }


        public string toString()
        {
            string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append("workspaceTransactionVOs: ");

            foreach (TransactionVOWS tvows in workspaceTransactionVOs)
            {
                thisString.Append((tvows != null) ? tvows.toString() : "<null>");
            }
            thisString.Append(NEW_LINE);
            thisString.Append("totalRowCount: ");
            thisString.Append(this.totalRowCount);
            thisString.Append(NEW_LINE);

            return thisString.ToString();
        }
    }
}
