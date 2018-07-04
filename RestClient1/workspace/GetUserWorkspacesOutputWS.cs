using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetUserWorkspacesOutputWS
    {
        // Instance variables

        /** The return code for the method call */
        public int returnCode { get; set; }
        /** The list of {@link WorkspaceVOWS} objects */
        public List<WorkspaceVOWS> workspaceVOWSs { get; set; }
        /** The total number of rows */
        public int totalRowCount { get; set; }

        public string toString() {
			string NEW_LINE = "\n";

            StringBuilder thisString = new StringBuilder();
			thisString.Append("returnCode: ");
			thisString.Append(this.returnCode);
			thisString.Append(NEW_LINE);
			thisString.Append("workspaceVOWSs: ");
            thisString.Append(NEW_LINE);
            foreach (WorkspaceVOWS wvows in workspaceVOWSs)
            {
                thisString.Append((wvows != null) ? wvows.toString() : "<null>");
                thisString.Append(NEW_LINE);
            }
            
			thisString.Append("totalRowCount: ");
			thisString.Append(this.totalRowCount);
			thisString.Append(NEW_LINE);

			return thisString.ToString();
		}
    }
}
